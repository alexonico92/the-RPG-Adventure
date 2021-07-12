using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestOpener : MonoBehaviour
{
    public GameObject spawnObject;
    public Transform spawnPoint;
    public Animator anim;
    public Text text;

    private int opened = 0;
    private bool spawned = false;

    void Start()
    {
        anim.SetBool("canOpen", false);
        text.enabled = false;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" && opened == 0)
        {
            text.enabled = true;
            if (Input.GetKeyDown(KeyCode.E) && spawned == false)
            {
                anim.SetBool("canOpen", true);
                Spawn();
                opened++;
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

    void Spawn()
    {
        Instantiate(spawnObject, spawnPoint.transform.position, Quaternion.identity);
        spawned = true;
    }
}
