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

    public GameObject player;
    public Text text;
    public bool isEscape = false;

    private PlayerMovement script;

	// Use this for initialization
	void Start () {
        if (player != null) script = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Escape") && !isEscape && !script.isDisabled) isEscape = true;
        else if (Input.anyKeyDown && isEscape && !script.isDisabled)
            if (!Input.GetButtonDown("Escape"))
                isEscape = false;
            else Application.Quit();
        else if (player != null)
            if (Input.GetButtonDown("Escape") && script.isDisabled)
            {
                script.isDisabled = false;
                if (script.currentImage != null) script.currentImage.enabled = false;
                script.currentImage = null;
            }

        if (isEscape) text.enabled = true;
        else text.enabled = false;
	}
}
