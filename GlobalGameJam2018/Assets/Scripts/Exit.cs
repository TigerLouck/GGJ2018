using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public string SceneToLoad;
    public bool isDone = false;
    public Animator animator;

	public void Open ()
    {
        isDone = true;
        animator.SetTrigger("OpenDoor");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(isDone) SceneManager.LoadScene(SceneToLoad);
    }

}
