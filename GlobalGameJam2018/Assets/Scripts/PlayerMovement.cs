using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * David Liu
 * Player Movement
 * Handles the left and right movement of the player using velocity and acceleration. Also switches the sprite.
 */
public class PlayerMovement : MonoBehaviour {

    // Variables
    public float position;
    public float velocity;
    public float acceleration;
    public float maxVelocity;
    public SpriteRenderer playerSprite;
    public float leftBound;
    public float rightBound;
    public bool isLeft = false;
    public bool isDisabled = false;
    public Image currentImage;
    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Player Input
        if(!isDisabled)
        {
            if (Input.GetAxis("Horizontal") < 0) // Left
            {
                isLeft = true;
                playerSprite.flipX = true;
                if (velocity <= -maxVelocity) velocity = -maxVelocity;
                else velocity -= acceleration;
                anim.SetBool("Walking", true);
            }
            else if (Input.GetAxis("Horizontal") > 0) // Right
            {
                isLeft = false;
                playerSprite.flipX = false;
                if (velocity >= maxVelocity) velocity = maxVelocity;
                else velocity += acceleration;
                anim.SetBool("Walking", true);
            }
            else if (velocity != 0)
            {
                velocity = 0; // Stop immediately
                anim.SetBool("Walking", false);
            }
        }
        else
        {
            velocity = 0; // Stop immediately
            anim.SetBool("Walking", false);
        }

        // Change Position
        position += velocity;
        position = Mathf.Clamp(position, leftBound, rightBound);
        if (transform.position.x == position) anim.SetBool("Walking", false);
        transform.position = new Vector3(position, transform.position.y, transform.position.z);
    }
}
