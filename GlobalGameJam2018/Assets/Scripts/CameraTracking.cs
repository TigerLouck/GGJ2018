using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Camera Tracking
 * Camera tracks the player's movement and stays focused on a specific height.
 * Attach this script to the camera.
 */
public class CameraTracking : MonoBehaviour {

    // Variables
    public GameObject player;
    public float height;

	// Use this for initialization
	void Start () {
        if (player == null)
            Debug.LogError("Player is not defined in CameraTracking script!");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(player.transform.position.x, height, gameObject.transform.position.z);
	}
}
