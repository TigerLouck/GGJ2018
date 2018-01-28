using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * David Liu
 * Interact Input
 * Player interaction input with objects.
 */
public class InteractInput : MonoBehaviour {
    // Variables
    private List<GameObject> interactables = new List<GameObject>();
    public Exit exit;

	// Use this for initialization
	void Start () {
        if (exit == null) Debug.LogError("Exit script is not defined in Interact Input script!");
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
        if (collision.tag == "Interactable")
            if (!interactables.Contains(collision.gameObject))
                interactables.Add(collision.gameObject);

        if(exit.isDone && collision.tag == "Exit") SceneManager.LoadScene(exit.SceneToLoad);
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
