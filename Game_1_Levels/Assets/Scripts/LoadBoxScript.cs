using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBoxScript : MonoBehaviour
{
    void Start()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
