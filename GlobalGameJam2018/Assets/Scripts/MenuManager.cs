using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Instructions ()
    {
        Debug.Log("chose instructions");
        SceneManager.LoadScene("Instructions", LoadSceneMode.Single);
    }

    public void GoExplorer ()
    {
        Debug.Log("chose Explorer");
    }

    public void GoResearcher ()
    {
        Debug.Log("chose researcher");
    }
}
