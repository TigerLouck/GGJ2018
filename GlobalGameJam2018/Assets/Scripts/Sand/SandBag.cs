using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Sand Bag
 * Bag that loses sand when the player interacts with it.
 * Changes the SandWeight variable in Puzzle Master.
 */
public class SandBag : MonoBehaviour {

    // Variables
    public GameObject puzzleMaster;
    public SandBagHold sandBagHoldScript;

    // Use this for initialization
    void Start () {
        if (sandBagHoldScript == null) Debug.LogError("Sand Bag Hold script was not found in Sand Bag script!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        if (!sandBagHoldScript.isHeld) puzzleMaster.SendMessage("RemoveSand");
        else puzzleMaster.SendMessage("PlaceBagScale");
    }
}
