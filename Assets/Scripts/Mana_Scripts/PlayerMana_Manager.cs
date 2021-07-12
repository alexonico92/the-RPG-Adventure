using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana_Manager : MonoBehaviour
{
    public int playerMaxMana;
    public int playerCurrentMana;

    void Start()
    {
        playerCurrentMana = playerMaxMana;
    }

    void Update()
    {
        if (playerCurrentMana > playerMaxMana)
        {
            playerCurrentMana = playerMaxMana;
        }
    }

    public void TakeMana(int manaToTake)
    {
        playerCurrentMana -= manaToTake;
    }

    public void GiveMana(int manaToGive)
    {
        playerCurrentMana += manaToGive;
    }

    public void SetMaxHMana()
    {
        playerCurrentMana = playerMaxMana;
    }
}
