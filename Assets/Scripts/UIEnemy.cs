using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemy : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public EnemyHealth_Manager enemyHealth;
    public Canvas enemyInfos;

    void Start()
    {
        enemyInfos.enabled = false;
    }

    void Update()
    {
        healthBar.maxValue = enemyHealth.MaxHealth;
        healthBar.value = enemyHealth.CurrentHealth;
        HPText.text = "HP: " + enemyHealth.CurrentHealth + "/" + enemyHealth.MaxHealth;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemyInfos.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            enemyInfos.enabled = false;
        }
    }
}
