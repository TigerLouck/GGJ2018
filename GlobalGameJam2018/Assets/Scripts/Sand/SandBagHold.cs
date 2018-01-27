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
    public bool isHeld = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        isHeld = true;
        puzzleMaster.SendMessage("HoldBag");
    }
}
