using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * pressure plate interaction handler
 */
public class PressurePlate : MonoBehaviour {

    public GameObject puzzleMaster;
    public int plateCode;

    public void Depress()
    {
        puzzleMaster.SendMessage("HitPlate", plateCode);
    }

}
