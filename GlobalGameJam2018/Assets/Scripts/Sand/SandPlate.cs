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
    public SandBagHold sandBagHoldScript;

    // Use this for initialization
    void Start () {
        if (sandBagHoldScript == null) Debug.LogError("Sand Bag Hold script was not found in Sand Plate script!");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        if(sandBagHoldScript.isHeld) puzzleMaster.SendMessage("TestSand");
    }
}
