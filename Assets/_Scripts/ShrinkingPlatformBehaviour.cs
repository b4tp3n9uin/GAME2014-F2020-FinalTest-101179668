using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Source File Name: ShrinkingPlatformBehaviour.cs
* Student Name: Matthew Makepeace
* Student ID: 101179668
* Date Last Modified: 12/15/2020
* Program Description: Shrinking Platform movement, Size, and controls.
* Modifications: Made the Shrinking Plaform move slightly up and down, and behaviour when player is on the platform to shrink and grow.
*/

public enum PlatformSounds
{
    SHRINK,
    GROW
}

public class ShrinkingPlatformBehaviour : MonoBehaviour
{
    public float dirY;
    public float moveSpeed;
    public bool movingUp;
    public bool isActive;
    public float max, min;

    public float shrinkRate;

    public AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;

        sounds = GetComponents<AudioSource>();
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
            sounds[(int)PlatformSounds.SHRINK].Play();

            if (gameObject.transform.localScale.x < 0.1f)
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
            if (gameObject.transform.localScale.x != 10.0f)
            {
                sounds[(int)PlatformSounds.GROW].PlayDelayed(0.1f);
                StartCoroutine("ScaleBack");
            }
        }
        
    }

    private IEnumerator ScaleBack()
    {
        yield return new WaitForSeconds(2.0f);
        gameObject.transform.localScale = new Vector2(10.0f, 7.0f);
    }
}
