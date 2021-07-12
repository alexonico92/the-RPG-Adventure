using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Slider healthBar;
    public Text HPText;
    public PlayerHealth_Manager playerHealth;

    public Slider manaBar;
    public Text manaText;
    public PlayerMana_Manager playerMana;

    public Text levelText;

    private PlayerStats thePS;
    private static bool UIExist;

    void Start()
    {
        if(!UIExist)
        {
            UIExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
    }

    void Update()
    {
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

        manaBar.maxValue = playerMana.playerMaxMana;
        manaBar.value = playerMana.playerCurrentMana;
        manaText.text = "MANA: " + playerMana.playerCurrentMana + "/" + playerMana.playerMaxMana;

        levelText.text = "Level: " + thePS.currentLevel;
    }
}
