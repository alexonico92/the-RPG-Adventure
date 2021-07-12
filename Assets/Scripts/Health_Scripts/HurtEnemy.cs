using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damageToGive;
    public GameObject damageBurst;
    public Transform hitPoint;
    public GameObject damageNumber;

    private int currentDamage;

    private PlayerStats thePS;

    void Start()
    {
        thePS = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePS.currentAttack;

            col.gameObject.GetComponent<EnemyHealth_Manager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber, hitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumbers>().damageNumber = currentDamage;
        }
    }

    public void IncreaseDamage(int damageIncrease)
    {
        damageToGive += damageIncrease;
    }
}
