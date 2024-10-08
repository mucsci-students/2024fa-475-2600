using System.Collections;
using System.Collections.Generic;
using EthanTheHero;
using UnityEngine;

public class SwapCaveSounds : MonoBehaviour
{
    public PlayerMovement script;
    [SerializeField] private float prevRunVolume;
    [SerializeField] private AudioClip prevRunSound;
    [SerializeField] private float newRunVolume;
    [SerializeField] private AudioClip newRunSound;
    [SerializeField] private AudioClip prevWallSlidingSound;
    [SerializeField] private AudioClip newWallSlidingSound;
    void OnTriggerEnter2D ()
    {
        script.runSound = newRunSound;
        script.runSoundVolume = newRunVolume;
        script.wallSlidingSound = newWallSlidingSound;
    }
    void OnTriggerExit2D ()
    {
        script.runSound = prevRunSound;
        script.runSoundVolume = prevRunVolume;
        script.wallSlidingSound = prevWallSlidingSound;
    }
}
