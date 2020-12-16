using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformBehaviour : MonoBehaviour
{
    public float dirY;
    public float moveSpeed;
    public bool movingUp;
    public bool isActive;
    public float max, min;

    public float shrinkRate;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckActivation();
    }

    void CheckDirection()
    {
        if (transform.position.y >  max)
            movingUp = false;

        else if (transform.position.y <  min)
            movingUp = true;
    }

    void Move()
    {
        CheckDirection();

        if (movingUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);

        else
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
    }

    private void CheckActivation()
    {
        if (isActive)
        {
            if (gameObject.transform.localScale.x < 0.0f)
            {
                gameObject.transform.localScale = new Vector2(0.01f, transform.localScale.y);
            }
            else
            {
                gameObject.transform.localScale = new Vector2(transform.localScale.x - 3 * Time.deltaTime, transform.localScale.y);
            }
        }
        else
        {
            StartCoroutine("ScaleBack");
        }
        
    }

    private IEnumerator ScaleBack()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.transform.localScale = new Vector2(10.0f, 7.0f);
    }
}
