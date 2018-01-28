using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * David Liu
 * Color Button
 * Goes through a list of colors.
 * Make sure to line up the same amount of colors with the Puzzle Master script.
 * HEX CODES DO NOT WORK. USE RGB!
 */
public class ColorButton : MonoBehaviour {

    // Variables
    public GameObject puzzleMaster;
    public Sprite currentColor;
    public Sprite wrongColor;
    public Sprite correctColor;
    public int patternLength;
    public List<Sprite> allColors = new List<Sprite>();
    public Sprite[] allColorPaths;

    private PuzzleMaster script;
    private SpriteRenderer spriteRenderer;
    private List<List<Sprite>> colors = new List<List<Sprite>>();

    // Use this for initialization
    void Start () {
        if (puzzleMaster == null) Debug.LogError("Puzzle Master object is not defined in Color Button script!");
        if (wrongColor == null) Debug.LogError("Wrong Color is not defined in " + gameObject.name + " Color Button script!");
        if (correctColor == null) Debug.LogError("Correct Color is not defined in " + gameObject.name + " Color Button script!");

        script = puzzleMaster.GetComponent<PuzzleMaster>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        int result = 1;
        result = (int)(Mathf.Pow(3, patternLength - 1) * patternLength);

        allColorPaths = new Sprite[result];
        for (int j = 0; j < allColors.Count; j++)
            RecurseColors(result, 0, 0, -1, 0, true);

        for (int i = 0; i < allColorPaths.Length; i++)
        {
            List<Sprite> colorList = new List<Sprite>();
            colors.Add(colorList);
            for (int j = 0; j < patternLength; j++)
            {
                colorList.Add(allColorPaths[i]);
                i++;
            }
        }

        if (colors.Count != script.colorCodes.Count) Debug.LogError("Colors list does not line up with Puzzle Master code in " + gameObject.name + " Color Button script!");
        else
            for (int i = 0; i < script.colorCodes.Count; i++)
                if (colors[i].Count != script.colorCodes[i].Count)
                    Debug.LogError("Colors list does not line up with Puzzle Master code in " + gameObject.name + " Color Button script!");
    }
	
	// Update is called once per frame
	void Update () {
        // Set object to tinted color
        if (script.position != script.colorCodes[script.codePosition].Count) currentColor = colors[script.codePosition][script.position];

        if (script.isWrong) currentColor = wrongColor;
        if (script.isCompleted) currentColor = correctColor;
        spriteRenderer.sprite = currentColor;
	}

    public void Interact()
    {
        if(!script.isWrong && !script.isCompleted) puzzleMaster.SendMessage("InputColor", colors);
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
}
