using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Manager script;
    public GameObject flag;
    [SerializeField] private AudioClip checkPointSound;
    public int spawn = 1;

    void Start()
    {
        flag.GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            flag.GetComponent<SpriteRenderer>().enabled = true;
            SoundFXManager.instance.PlaySoundFXClip(checkPointSound, transform, 0.1f);
            script.setSpawnPoint(spawn);
            Destroy(this);
        }
    }
}
