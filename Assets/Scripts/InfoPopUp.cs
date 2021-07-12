using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopUp : MonoBehaviour
{
    [SerializeField]
    private Text yourText;

    void Start()
    {
        yourText.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            yourText.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            yourText.enabled = false;
        }
    }
}
