using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest01Starter : MonoBehaviour
{

    [SerializeField] private Text text;
    [SerializeField] private Text questText;
    [SerializeField] private Image image;
    public int questCounter = 0;
    private int textShow = 0;

    void Start()
    {
        text.enabled = false;
        image.enabled = false;
        questText.enabled = false;
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           if(questCounter < 1)
            {
                text.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    image.enabled = true;
                    questText.enabled = true;
                    textShow ++;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            text.enabled = false;
            image.enabled = false;
            questText.enabled = false;
            counterCheck();
        }
    }

    public void counterCheck()
    {
        if(questCounter < 1)
        {
            if (textShow > 0)
            {
                questCounter++;
            }
        }
    }
}
