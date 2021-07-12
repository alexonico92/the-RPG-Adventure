using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    public Canvas inv;
    private bool opened;

    void Start()
    {
        inv.enabled = false;
        opened = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && opened == false)
        {
            inv.enabled = true;
            opened = true;
        }
        else if(Input.GetKeyDown(KeyCode.I) && opened == true)
        {
            inv.enabled = false;
            opened = false;
        }
    }
}
