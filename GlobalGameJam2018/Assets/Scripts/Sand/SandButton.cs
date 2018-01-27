using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Sand Button
 * Button in the sand puzzle that drops sand into the bag.
 * Changes the SandWeight variable in Puzzle Master.
 */
public class SandButton : MonoBehaviour {

    // Variables
    public GameObject puzzleMaster;

    // Use this for initialization
    void Start () {
        // Reference this script in the puzzle master
        PuzzleMaster script = puzzleMaster.GetComponent<PuzzleMaster>();
        script.sandButton = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        puzzleMaster.SendMessage("AddSand");
    }
}
