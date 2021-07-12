using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
    private PlayerHealth_Manager PHM;

    public int healingPoints;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PHM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth_Manager>();
    }

    public void Use()
    {
        PHM.HealPlayer(healingPoints);

        Instantiate(effect, player.position, player.rotation);
        Destroy(gameObject);
    }
}
