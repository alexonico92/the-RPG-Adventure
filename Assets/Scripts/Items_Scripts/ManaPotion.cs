using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
    private PlayerMana_Manager PMM;

    public int manaToGive;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        PMM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana_Manager>();
    }

    public void Use()
    {
        PMM.GiveMana(manaToGive);

        Instantiate(effect, player.position, player.rotation);
        Destroy(gameObject);
    }
}
