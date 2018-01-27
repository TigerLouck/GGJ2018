﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        else if (velocity != 0) velocity = 0; // Stop immediately

        // Change Position
        position += velocity;
        gameObject.transform.position = new Vector3(position, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}