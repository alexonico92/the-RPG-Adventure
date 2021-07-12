using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{

    public int damageToGive;
    public GameObject damageNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth_Manager>().HurtPlayer(damageToGive);

            var clone = (GameObject)Instantiate(damageNumber, col.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumbers>().damageNumber = damageToGive;
        }
    }
}
