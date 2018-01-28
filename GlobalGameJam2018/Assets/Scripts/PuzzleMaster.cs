using System.Collections;
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
    private int sandWeight = 10;
    private int sandCap = 20;
    private int sandAnswer = 17;

    // Reference each object and script
    public GameObject sandBagObject;
    public GameObject rockScaleObject;
    public SandButton sandButton;
    public SandBag sandBag;
    public SandPlate sandPlate;
    public SandBagHold sandBagHold;
    public GameObject ScaleArm;
    public float heightChange = 0.005f;
    #endregion

    #region Color Puzzle Variables
    public int patternLength;
    public List<Sprite> allColors = new List<Sprite>();
    public Sprite[] allColorPaths;
    public List<List<Sprite>> colorCodes = new List<List<Sprite>>();
    public int codePosition = 0;
    public int position = 0;
    public bool isWrong = false;
    public bool isCompleted = false;
    #endregion

    public GameObject exit;

    public void Start()
    {
        int result = 1;
        result = (int)(Mathf.Pow(3, patternLength - 1) * patternLength);

        allColorPaths = new Sprite[result];
        for(int j = 0; j < allColors.Count; j++)
            RecurseColors(result, 0, 0, -1, 0, true);

        for (int i = 0; i < allColorPaths.Length; i++)
        {
            List<Sprite> colorList = new List<Sprite>();
            colorCodes.Add(colorList);
            for (int j = 0; j < patternLength; j++)
            {
                colorList.Add(allColorPaths[i]);
                i++;
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
            ScaleArm.transform.rotation *= Quaternion.Euler(0, 0, 1);
            rockScaleObject.transform.rotation = Quaternion.Euler(0,0,-1);
            sandBag.transform.rotation = Quaternion.Euler(0, 0, -1);
            sandBagObject.transform.rotation = Quaternion.Euler(0, 0, -1);
        }
    }

    // Removes sand from the bag
    public void RemoveSand()
    {
        if (sandWeight != 0 && !sandBagHold.isHeld && !sandPlate.onPlate)
        {
            sandWeight--;
            ScaleArm.transform.rotation *= Quaternion.Euler(0, 0, -1);
            rockScaleObject.transform.rotation = Quaternion.Euler(0, 0, 1);
            sandBag.transform.rotation = Quaternion.Euler(0, 0, 1);
            sandBagObject.transform.rotation = Quaternion.Euler(0, 0, 1);
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
        else if(sandPlate.onPlate)
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
    public void InputColor(List<List<Sprite>> colors)
    {
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

    // Don't ask me how this works
    public void RecurseColors(int count, int path, int counter, int index, int prevStart, bool firstRecursion)
    {
        if (!firstRecursion) count = count / 3;
        if (count == 1) return;
        else
        {
            switch (path)
            {
                case 0:
                    index++;
                    break;
                case 1:
                    index += 2;
                    break;
                case 2:
                    index += 3;
                    break;
            }

            int start = prevStart + (count * path) + counter;
            float length = 0;
            if (firstRecursion) length = count;
            else length = count + start;
            int trueIndex = index;
            if (path != 0) trueIndex = index + (path * 3);
            else trueIndex = index;
            for (int i = start; i < length; i += patternLength)
            {
                allColorPaths[i] = allColors[trueIndex];
            }
            if (!firstRecursion) prevStart = start - counter;
            counter++;
            firstRecursion = false;

            RecurseColors(count, 0, counter, index, prevStart, firstRecursion);
            RecurseColors(count, 1, counter, index, prevStart, firstRecursion);
            RecurseColors(count, 2, counter, index, prevStart, firstRecursion);
        }
    }
    #endregion
}
