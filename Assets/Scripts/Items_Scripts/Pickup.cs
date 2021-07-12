using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private bool collid;

    private void Start()
    {
        collid = false;
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collid) return;

        if(other.CompareTag("Player") && !collid)
        {
            collid = true;

            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    StartCoroutine(Reset());
                    break;
                }
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForEndOfFrame();
        collid = false;
    }
}
