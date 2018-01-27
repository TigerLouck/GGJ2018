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
    private SandBagHold sandBagHoldScript;
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
        if (sandWeight != sandCap) sandWeight++;
    }

    // Removes sand from the bag
    public void RemoveSand()
    {
        if (sandWeight != 0) sandWeight--;
    }

    // Places bag on plate and tests the code
    public bool TestSand(SandBagHold script)
    {
        if (script.isHeld)
        {
            // Code for placing bag on plate here
            if (sandWeight == sandAnswer) return true;
            return false;
        }
        script.isHeld = true;
        return false;
    }

    // Places bag visibly on the scale part
    public void PlaceBagScale(SandBagHold script)
    {
        // Code for placing bag back on scale
        script.isHeld = false;
    }
    #endregion
}
