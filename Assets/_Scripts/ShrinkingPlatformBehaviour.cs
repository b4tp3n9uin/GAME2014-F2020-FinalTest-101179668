using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingPlatformBehaviour : MonoBehaviour
{
    public float dirY;
    public float moveSpeed;
    public bool movingUp;
    public float max, min;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
}
