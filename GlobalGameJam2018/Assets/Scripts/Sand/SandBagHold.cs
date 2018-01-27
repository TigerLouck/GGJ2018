using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Sand Bag Hold
 * Handles when the player picks up the sand bag with the string.
 */
public class SandBagHold : MonoBehaviour {

    // Variables
    public GameObject puzzleMaster;
    public GameObject player;
    public GameObject sandBag;
    public bool isHeld = false;
    public float holdDistance = 0.5f;
    public float holdHeight = 0f;

    private PlayerMovement movementScript;

	// Use this for initialization
	void Start () {
        if (sandBag == null) Debug.LogError("Sand Bag object was not found in SandBagHold script!");
        if (player == null) Debug.LogError("Player object was not found in SandBagHold script!");
        movementScript = player.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
		if(isHeld)
        {
            // Code for holding the bag here
            if (movementScript.isLeft) sandBag.transform.position = new Vector3(player.transform.position.x - holdDistance, player.transform.position.y + holdHeight, sandBag.transform.position.z);
            else sandBag.transform.position = new Vector3(player.transform.position.x + holdDistance, player.transform.position.y + holdHeight, sandBag.transform.position.z);
        }
	}

    public void Interact()
    {
        isHeld = true;
    }
}
