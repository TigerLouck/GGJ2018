using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * David Liu
 * Esc Input
 * Prompts the user to quit the game
 */
public class EscInput : MonoBehaviour {

    public Text text;

    public bool isEscape = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Escape") && !isEscape) isEscape = true;
        else if (Input.anyKeyDown && isEscape)
            if (!Input.GetButtonDown("Escape"))
                isEscape = false;
            else Application.Quit();

        if (isEscape) text.enabled = true;
        else text.enabled = false;
	}
}
