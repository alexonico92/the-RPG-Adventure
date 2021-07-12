using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine("PlatformFall");
        }
    }

    IEnumerator PlatformFall()
    {
        yield return new WaitForSeconds(1);
        rb.isKinematic = false;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
