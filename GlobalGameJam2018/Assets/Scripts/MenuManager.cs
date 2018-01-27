using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void Instructions ()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Explorer()
    {
        SceneManager.LoadScene("PressurePlateCode");
    }

    public void Researcher()
    {
        SceneManager.LoadScene("Researcher");
    }

    public void Exit ()
    {
        Application.Quit();
    }
}
