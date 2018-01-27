using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Player Movement
 */
public class PlayerMovement : MonoBehaviour {

    // Variables
    public float velocity;
    public float acceleration;
    public float maxVelocity;
    public SpriteRenderer playerSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Player Input
        if (Input.GetAxis("Horizontal") < 0) // Left
        {
            playerSprite.flipX = true;
            if (velocity <= -maxVelocity) velocity = -maxVelocity;
            else velocity -= acceleration;
        }
        else if (Input.GetAxis("Horizontal") > 0) // Right
        {
            playerSprite.flipX = false;
            if (velocity >= maxVelocity) velocity = maxVelocity;
            else velocity += acceleration;
        }
        else if (velocity != 0) velocity *= 0.5f;// No movement
    }
}
