using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Reset Colors
 * Resets the color code in the Puzzle Master.
 */
public class ResetColors : MonoBehaviour {

    // Variables
    public GameObject puzzleMaster;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        puzzleMaster.SendMessage("ResetColorPuzzle");
    }
}
