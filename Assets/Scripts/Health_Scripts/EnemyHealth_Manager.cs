using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth_Manager : MonoBehaviour
{

    public int MaxHealth;
    public int CurrentHealth;
    public int expToGive;

    public Animator animator;

    private PlayerStats thePlayerStats;

    SpriteRenderer rend;

    void Start()
    {
        CurrentHealth = MaxHealth;

        rend = GetComponentInChildren<SpriteRenderer>();
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            StartCoroutine("ObjectRemover");
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }

    IEnumerator ObjectRemover()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
            StartCoroutine("ObjectDestroyer");
        }
    }

    IEnumerator ObjectDestroyer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        thePlayerStats.AddExperience(expToGive);
    }
}

