using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode : MonoBehaviour {

    public Color color;
    public TreeNode[] nodeList = new TreeNode[3];

    public TreeNode(Color c)
    {
        color = c;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
