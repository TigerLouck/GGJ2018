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
    public void RemoveSand()
    {
        if (sandWeight != 0) sandWeight--;
    }

    public void AddSand()
    {
        if (sandWeight != sandCap) sandWeight++;
    }

    public bool TestSand()
    {
        if (sandWeight == sandAnswer) return true;
        return false;
    }
    #endregion
}
