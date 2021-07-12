using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControll : MonoBehaviour
{

    public GameObject spawnObject;
    public Transform spawnPoint;

    private Quest01Starter Q01S;

    private bool spawned = false;

    void Start()
    {
        Q01S = FindObjectOfType<Quest01Starter>();
    }

    void Update()
    {
        if (Q01S.questCounter >= 1 && spawned == false)
        {
            SpawnTroll();
        }
    }

    void SpawnTroll()
    {
        Instantiate(spawnObject, spawnPoint.transform.position, Quaternion.identity);
        spawned = true;
    }
}