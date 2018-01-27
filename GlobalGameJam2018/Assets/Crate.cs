using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//crate interaction handler by Tiger Louck
public class Crate : MonoBehaviour {
    //inspector variables
    public bool isHeld = false;
    public GameObject Player;
    public Transform[] buttons;
    public float playerHoldHeight;
    public float buttonHoldHeight;
	// Update is called once per frame
	void Update () {
       if (isHeld)
        {
            transform.position = Player.transform.position + Vector3.up * playerHoldHeight;
        }
        else
        {
            float dist = 100;
            GameObject closest = null;
            foreach (Transform button in buttons)
            {
                if (Mathf.Abs(button.position.x - transform.position.x ) < dist)
                {
                    transform.position = button.position + Vector3.up * buttonHoldHeight;
                    closest = button.gameObject;
                }
            }
        }
	}

    public void Interact()
    {
        isHeld = !isHeld;
    }
}
