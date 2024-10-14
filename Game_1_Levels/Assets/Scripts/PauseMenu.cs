using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private GameObject screen;
    public Manager script;
    private bool paused = false;
    void Start()
    {
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
        paused = false;
        Time.timeScale = 1;
    }
    public void ExitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
