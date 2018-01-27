using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Tiger Louck, David Liu
 * puzzle master game controller script, handles the pressure plate combo lock, the scale, and the color tree puzzles.
 */
public class PuzzleMaster : MonoBehaviour {

    private int[] plateCombo = new int[6] { 2, 3, 3, 0, 4, 3 };
    private int lockState = 0;

    #region Sand Puzzle Variables
    private int sandWeight = 0;
    private int sandCap = 20;
    private int sandAnswer = 17;

    // Reference each object and script
    public GameObject sandBagObject;
    public GameObject rockScaleObject;
    public SandButton sandButton;
    public SandBag sandBag;
    public SandPlate sandPlate;
    public SandBagHold sandBagHold;
    public float heightChange = 0.05f;
    #endregion

    public GameObject exit;
	public void HitPlate(int plateCode)
    {
        Debug.Log(plateCode);

        if (plateCode == plateCombo[lockState])
            lockState++;
        else lockState = 0;

        if (lockState == plateCombo.Length)
            exit.SendMessage("Open");
            
    }

    #region Sand Puzzle Methods
    // Adds sand to the bag
    public void AddSand()
    {
        if (sandWeight != sandCap && !sandBagHold.isHeld && !sandPlate.onPlate)
        {
            sandWeight++;
            sandBag.gameObject.transform.position += new Vector3(0, heightChange, 0);
            sandBagObject.transform.position += new Vector3(0, heightChange, 0);
            rockScaleObject.transform.position -= new Vector3(0, heightChange, 0);
        }
    }

    // Removes sand from the bag
    public void RemoveSand()
    {
        if (sandWeight != 0 && !sandBagHold.isHeld && !sandPlate.onPlate)
        {
            sandWeight--;
            sandBag.gameObject.transform.position -= new Vector3(0, heightChange, 0);
            sandBagObject.transform.position -= new Vector3(0, heightChange, 0);
            rockScaleObject.transform.position += new Vector3(0, heightChange, 0);
        }
    }

    // Places bag on plate and tests the code
    public void TestSand()
    {
        if (sandBagHold.isHeld)
        {
            if (sandWeight == sandAnswer) Debug.Log("Success!");
            else Debug.Log("Wrong!");
            sandBagHold.isHeld = false;
            sandPlate.onPlate = true;
            sandBagObject.transform.position = sandPlate.transform.position + new Vector3(0, sandBagObject.GetComponent<SpriteRenderer>().bounds.extents.y, 0);
        }
        else
        {
            sandBagHold.isHeld = true;
            sandPlate.onPlate = false;
        }
    }

    // Places bag visibly on the scale part
    public void PlaceBagScale()
    {
        sandBagHold.isHeld = false;
        sandBagObject.transform.position = sandBag.transform.position;
    }

    // Makes the player hold the sand bag
    public void HoldBag()
    {
        sandBagHold.isHeld = true;
        sandPlate.onPlate = false;
    }
    #endregion
}
