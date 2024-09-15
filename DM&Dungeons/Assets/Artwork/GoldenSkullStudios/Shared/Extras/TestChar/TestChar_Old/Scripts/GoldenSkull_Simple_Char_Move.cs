﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GoldenSkull_Simple_Char_Move : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;

    [SerializeField]
    Animator animator;

    private Vector3 startScale;

    [SerializeField]
    private SpriteRenderer characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        characterSprite = GetComponent<SpriteRenderer>();
        startScale = this.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    void SetAnimatorStates(float _currSpeed)
    {
        if( animator!= null)
        {
            animator.SetFloat("speed", _currSpeed);
        }
    }

    void MoveCharacter()
    {
        //I am putting these placeholder variables here, to make the logic behind the code easier to understand
        //we differentiate the movement speed between horizontal(x) and vertical(y) movement, since isometric uses "fake perspective"
        float horizontalMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        //since we are using this with isometric visuals, the vertical movement needs to be slower
        //for some reason, 50% feels too slow, so we will be going with 75%
        float verticalMovement = Input.GetAxisRaw("Vertical") * speed * 0.5f * Time.deltaTime;

        float totalMovement = Mathf.Abs(horizontalMovement + verticalMovement);

        SetAnimatorStates(totalMovement * 100);

        if ( totalMovement != 0 )
        {
            FlipSpriteToMovement();
        }

        this.transform.Translate(horizontalMovement, verticalMovement, 0);
    }

    //if the player moves left, flip the sprite, if he moves right, flip it back, stay if no input is made
    void FlipSpriteToMovement()
    {
        Vector3 currScale = startScale;

        if (Input.GetAxisRaw("Horizontal") < 0)
            currScale.x = -startScale.x;
        else if (Input.GetAxisRaw("Horizontal") > 0)
            currScale.x = startScale.x;

        this.transform.localScale = currScale;

        return;
        /*
        if(characterSprite != null )
        {
            if (Input.GetAxisRaw("Horizontal") < 0)
                characterSprite.flipX = true;
            else if (Input.GetAxisRaw("Horizontal") > 0)
                characterSprite.flipX = false;
        }
        */
    }
}
