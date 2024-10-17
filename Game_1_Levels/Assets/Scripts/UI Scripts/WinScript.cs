using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    private GameObject screen;

    void Start()
    {
        screen = GameObject.Find("WinScreen");
        screen.SetActive(false);
    }
    public void Win()
    {
        Time.timeScale = 0;
        PlayerPrefs.SetInt("tempspawn", 3);
        screen.SetActive(true);
    }
}
