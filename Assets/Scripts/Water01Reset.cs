using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water01Reset : MonoBehaviour
{
    private GameMaster gm;
    private PlayerHealth_Manager PHM;

    public GameObject player;
    public int liveToTake;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        PHM = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth_Manager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player.transform.position = gm.lastCheckPointPos;
            col.gameObject.GetComponent<PlayerLives>().TakeLive(liveToTake);
            PHM.ResetStatsAfter();
        }
    }
}
