﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Tiger Louck, David Liu, Sam Keir
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

    #region Color Puzzle Variables
    public int patternLength;
    public List<Color> allColors = new List<Color>();
    public List<List<Color>> colorCodes = new List<List<Color>>();
    public int codePosition = 0;
    public int position = 0;
    public bool isWrong = false;
    public bool isCompleted = false;
    #endregion

    public GameObject exit;

    public void Start()
    {
        int counter = 0;
        while (allColors.Count != 0)
        {
            List<Color> colorList = new List<Color>();
            colorCodes.Add(colorList);
            counter = 0;
            while (counter != patternLength || allColors.Count != 0)
            {
                counter++;
                colorList.Add(allColors[0]);
                allColors.RemoveAt(0);
            }
        }

        codePosition = Random.Range(0, colorCodes.Count);
    }

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
            if (sandWeight == sandAnswer) exit.SendMessage("Open");
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

    #region Color Puzzle Methods
    // Receives input from a color button
    public void InputColor(List<List<Color>> colors)
    {
        Debug.Log(colors[position]);
        Debug.Log(colorCodes[codePosition][position]);
        if (colors[codePosition][position] == colorCodes[codePosition][position]) position++;
        else
        {
            isWrong = true;
            position = 0;
        }

        // Check if code is completed
        if (position == colors.Count)
        {
            exit.SendMessage("Open");
            isCompleted = true;
        }
    }

    // Resets the puzzle to the start of the code
    public void ResetColorPuzzle()
    {
        isWrong = false;
        if (!isCompleted)
        {
            position = 0;
            codePosition = Random.Range(0, colorCodes.Count);
        }
    }
    #endregion
}
