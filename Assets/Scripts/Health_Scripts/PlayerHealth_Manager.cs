using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth_Manager : MonoBehaviour
{
    private GameMaster gm;
    private PlayerMana_Manager PMM;

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public int liveToTake;

    public GameObject player;
    public Animator animator;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        PMM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana_Manager>();
    }

    void Update()
    {
        if(playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }

        if(playerCurrentHealth <= 0)
        {
            gameObject.GetComponent<CharMovement>().enabled = false;

            animator.SetBool("Death", true);

            TakeOneLive();
            ResetStats();
        }
    }

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }

    public void HealPlayer(int healingPoints)
    {
        playerCurrentHealth += healingPoints;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    public void TakeOneLive()
    {
        gameObject.GetComponent<PlayerLives>().TakeLive(liveToTake);
    }

    public void ResetStats()
    {
        playerCurrentHealth = playerMaxHealth;
        //player.transform.position = gm.lastCheckPointPos;
        //gameObject.GetComponent<CharMovement>().enabled = true;
        StartCoroutine("RespawnPlayer");
    }

    public void ResetStatsAfter()
    {
        player.transform.position = gm.lastCheckPointPos;
        gameObject.GetComponent<CharMovement>().enabled = true;
        animator.SetBool("Death", false);
        playerCurrentHealth = playerMaxHealth;
        PMM.SetMaxHMana();
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1);
        player.transform.position = gm.lastCheckPointPos;
        gameObject.GetComponent<CharMovement>().enabled = true;
        animator.SetBool("Death", false);
        playerCurrentHealth = playerMaxHealth;
        PMM.SetMaxHMana();
    }
}
