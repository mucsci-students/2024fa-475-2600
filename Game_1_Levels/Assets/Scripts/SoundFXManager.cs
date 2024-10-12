using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;

    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        if(instance != this)
        {
            instance = this;
        }
    }
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spawn in gameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //assign the audioClip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play souond
        audioSource.Play();

        //get length of sound FX clip
        float clipLength = audioSource.clip.length;

        //destory the clip after it is done playing
        Destroy(audioSource.gameObject, clipLength);
    }
}
