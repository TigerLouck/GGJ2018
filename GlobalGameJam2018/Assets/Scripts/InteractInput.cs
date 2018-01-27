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
        Debug.Log("Entered!");
        // Objects tagged with "Interactable" are put into the list
        if (collision.tag == "Interactable")
            Debug.Log("object encountered");
            if (!interactables.Contains(collision.gameObject))
            {
                interactables.Add(collision.gameObject);
                Debug.Log("interactable object encountered");
            }
    }

    // Exits trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited!");
        // Objects tagged with "Interactable" are taken out of the list
        if (collision.tag == "Interactable")
            if (interactables.Contains(collision.gameObject))
                interactables.Remove(collision.gameObject);
    }
}
