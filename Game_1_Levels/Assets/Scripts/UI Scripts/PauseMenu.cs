using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject screen;
    private GameObject controls;
    public Manager script;
    private bool paused = false;
    private bool controlsOpen = false;
    void Start()
    {
        controls = GameObject.Find("Controls");
        controls.SetActive(false);
        screen = GameObject.Find("PauseScreen");
        screen.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                Unpause();
            }
            else if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
                paused = true;
                screen.SetActive(true);
            }
        }
    }
    public void Unpause()
    {
        screen.SetActive(false);
        controls.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
    public void ExitToMenu()
    {
        PlayerPrefs.SetInt("tempspawn", 3);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void ToggleControls()
    {
        controlsOpen = !controlsOpen;
        controls.SetActive(controlsOpen);
    }
}
