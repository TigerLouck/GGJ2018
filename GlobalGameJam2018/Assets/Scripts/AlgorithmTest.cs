using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgorithmTest : MonoBehaviour {

    public int patternLength;
    public List<int> allColors = new List<int>();
    public int[] allColorPaths;

    // Use this for initialization
    void Start () {
        int result = 1;
        result = (int)(Mathf.Pow(3, patternLength - 1) * patternLength);

        allColorPaths = new int[result];
        for (int j = 0; j < allColors.Count; j++)
            RecurseColors(result, 0, 0, -1, 0, true);
    }
	
	// Update is called once per frame
	void Update () {
		
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
