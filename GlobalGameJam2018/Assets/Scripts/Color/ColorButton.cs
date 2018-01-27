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
    public Color currentColor;
    public Color wrongColor;
    public Color correctColor;
    public int patternLength;
    public List<Color> allColors = new List<Color>();

    private PuzzleMaster script;
    private SpriteRenderer spriteRenderer;
    private List<List<Color>> colors = new List<List<Color>>();

    // Use this for initialization
    void Start () {
        if (puzzleMaster == null) Debug.LogError("Puzzle Master object is not defined in Color Button script!");
        if (wrongColor == null) Debug.LogError("Wrong Color is not defined in " + gameObject.name + " Color Button script!");
        if (correctColor == null) Debug.LogError("Correct Color is not defined in " + gameObject.name + " Color Button script!");

        script = puzzleMaster.GetComponent<PuzzleMaster>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        int counter = 0;
        while(allColors.Count != 0)
        {
            List<Color> colorList = new List<Color>();
            colors.Add(colorList);
            counter = 0;
            while (counter != patternLength || allColors.Count != 0)
            {
                counter++;
                colorList.Add(allColors[0]);
                allColors.RemoveAt(0);
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
        spriteRenderer.color = currentColor;
	}

    public void Interact()
    {
        if(!script.isWrong && !script.isCompleted) puzzleMaster.SendMessage("InputColor", colors);
    }
}
