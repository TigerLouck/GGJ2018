﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InstructionsManager : MonoBehaviour
{

	public void Back ()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
