using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Sand Plate
 * Plate that tests the weight of the sand in order to advance.
 */
public class SandPlate : MonoBehaviour {

    // Variables
    public GameObject puzzleMaster;
    public bool onPlate = false;

    // Use this for initialization
    void Start () {
        // Reference this script in the puzzle master
        PuzzleMaster script = puzzleMaster.GetComponent<PuzzleMaster>();
        script.sandPlate = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        puzzleMaster.SendMessage("TestSand");
    }
}
