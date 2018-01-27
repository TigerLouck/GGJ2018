using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//crate interaction handler by Tiger Louck
public class Crate : MonoBehaviour {
    //inspector variables
    public bool isHeld = false;
    public GameObject player;
    public Transform[] buttons;
    public float playerHoldHeight;
    public float buttonHoldHeight;

    private bool justdropped = false;
    private float droppedX;
	// Update is called once per frame
	void Update () {
       if (isHeld)
        {
            transform.position = player.transform.position + Vector3.up * playerHoldHeight;

            droppedX = player.transform.position.x;
        }
        else
        {
            float dist = 100; //must be larger than player level bounds;
            GameObject closest = null;
            foreach (Transform button in buttons)
            {
                if (Mathf.Abs(droppedX - button.position.x) < dist)
                {
                    //Debug.Log("HOLP: " + droppedX);
                    transform.position = button.position + Vector3.up * buttonHoldHeight;
                    closest = button.gameObject;
                    dist = Mathf.Abs(droppedX - button.position.x);
                }
            }
            if (justdropped)
            {
                closest.SendMessage("Depress");
                justdropped = false;
            }
        }
	}

    public void Interact()
    {
        isHeld = !isHeld;
        if (isHeld == false)
            justdropped = true;
    }
}
