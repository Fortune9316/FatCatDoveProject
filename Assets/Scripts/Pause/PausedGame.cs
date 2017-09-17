using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedGame : MonoBehaviour {

    //Canvas canvas;
    public GameObject pauseBack;
    public GameObject pauseMenu;
	// Use this for initialization
	void Start () {
        //canvas = FindObjectOfType<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
	}

    public void Pause()
    {
        if (pauseBack.activeInHierarchy == false)
        {
            Time.timeScale = 0f;
            pauseBack.SetActive(true);
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseBack.SetActive(false);
            pauseMenu.SetActive(false);
        }
    }
}
