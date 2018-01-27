using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public GameObject puzzleMaster;
    public int plateCode;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Interact()
    {
        puzzleMaster.SendMessage("HitPlate", plateCode);
    }

    private void OnMouseDown()
    {
        Interact();
    }
}
