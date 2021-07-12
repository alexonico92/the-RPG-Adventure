using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour
{

    public Text info;
    public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;

    void Start()
    {
        info.enabled = false;
        dMAn = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            info.enabled = true;
            if(Input.GetKeyUp(KeyCode.E))
            {
                //dMAn.ShowBox(dialogue);

                if(!dMAn.dialogActive)
                {
                    dMAn.dialogLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            info.enabled = false;
        }
    }
}
