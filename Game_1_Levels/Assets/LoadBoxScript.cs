using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBoxScript : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Slime")
        {
            other.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (other.tag == "Skeleton")
        {
            other.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (other.tag == "Knight")
        {
            other.GetComponent<SpriteRenderer>().enabled = true;
        }

    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.tag == "Slime")
        {
            other.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (other.tag == "Skeleton")
        {
            other.transform.GetChild(0).gameObject.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (other.tag == "Knight")
        {
            other.GetComponent<SpriteRenderer>().enabled = false;
        }

    }
}
