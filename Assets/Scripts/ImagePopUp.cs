using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePopUp : MonoBehaviour
{
    [SerializeField] private Image customimage;

    void Start()
    {
        customimage.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            customimage.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            customimage.enabled = false;
        }
    }
}
