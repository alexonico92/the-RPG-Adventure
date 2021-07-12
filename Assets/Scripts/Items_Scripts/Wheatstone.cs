using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheatstone : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
    private HurtEnemy HE;

    public int damageIncrease;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        HE = GameObject.FindGameObjectWithTag("Weapon").GetComponent<HurtEnemy>();
    }

    public void Use()
    {
        HE.IncreaseDamage(damageIncrease);

        Instantiate(effect, player.position, player.rotation);
        Destroy(gameObject);
    }
}
