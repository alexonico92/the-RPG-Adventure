using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEnabler : MonoBehaviour
{
    public Animator anim;
    public Text text;

    private bool txtenabled;

    void Start()
    {
        anim.SetBool("keyPressed", false);
        text.enabled = false;
        txtenabled = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && txtenabled == true)
        {
            text.enabled = true;
            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("keyPressed", true);
                txtenabled = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            text.enabled = false;
        }
    }
}
