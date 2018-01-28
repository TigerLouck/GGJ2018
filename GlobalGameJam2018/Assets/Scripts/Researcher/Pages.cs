using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * David Liu
 * Pages
 * Interactions with the pages in the Researcher part of the game
 */
public class Pages : MonoBehaviour {

    // Variables
    public GameObject player;
    public Image image;

    private PlayerMovement script;

	// Use this for initialization
	void Start () {
        if (player == null) Debug.LogError("Player Object is not defined in" + gameObject.name + " Pages script!");
        if (image == null) Debug.LogError("Image UI is not defined in" + gameObject.name + " Pages script!");
        script = player.GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Interact()
    {
        if(script.isDisabled)
        {
            if(script.currentImage != null) script.currentImage = null;
            image.enabled = false;
            script.isDisabled = false;
        }
        else
        {
            script.currentImage = image;
            image.enabled = true;
            script.isDisabled = true;
        }
    }
}
