using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] manaLevels;

    public int currentHP;
    public int currentAttack;
    public int currentMana;

    private PlayerHealth_Manager PHM;
    private PlayerMana_Manager PMM;

    void Start()
    {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentMana = manaLevels[1];

        PHM = FindObjectOfType<PlayerHealth_Manager>();
        PMM = FindObjectOfType<PlayerMana_Manager>();
    }

    void Update()
    {
        if(currentExp >= toLevelUp[currentLevel])
        {
            LevelUp();
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;

        currentHP = HPLevels[currentLevel];
        PHM.playerMaxHealth = currentHP;
        PHM.playerCurrentHealth += currentHP - HPLevels[currentLevel - 1];

        currentAttack = attackLevels[currentLevel];

        currentMana = manaLevels[currentLevel];
        PMM.playerMaxMana = currentMana;
        PMM.playerCurrentMana += currentMana - manaLevels[currentLevel - 1];
    }
}
