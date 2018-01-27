using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour {

    private int[] plateCombo = new int[6] { 3, 4, 4, 1, 5, 4 };
    private int lockState = 0;

    public GameObject exit;
	public void HitPlate(int plateCode)
    {
        Debug.Log(plateCode);

        if (plateCode == plateCombo[lockState])
            lockState++;
        if (lockState == plateCombo.Length - 1)
            exit.SendMessage("Open");
            
    }
}
