using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Interact Input
 * Player interaction input with objects.
 */
public class InteractInput : MonoBehaviour {

    // Variables
    List<GameObject> interactables = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // Send a trigger to the object
        if (Input.GetButtonDown("Interact"))
            foreach (GameObject interactable in interactables)
                interactable.SendMessage("Interact");
    }

    // Enters trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Objects tagged with "Interactable" are put into the list
        if(collision.tag == "Interactable")
            if (!interactables.Contains(collision.gameObject))
                interactables.Add(collision.gameObject);
    }

    // Exits trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Objects tagged with "Interactable" are taken out of the list
        if (collision.tag == "Interactable")
            if (interactables.Contains(collision.gameObject))
                interactables.Remove(collision.gameObject);
    }
}
