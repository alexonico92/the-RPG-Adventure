using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;
    private EnemyHealth_Manager EHM;

    void Start ()
    {
        EHM = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth_Manager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth_Manager>().HurtEnemy(damageToGive);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumbers>().damageNumber = damageToGive;
            Destroy(gameObject);
        }
    }
}
