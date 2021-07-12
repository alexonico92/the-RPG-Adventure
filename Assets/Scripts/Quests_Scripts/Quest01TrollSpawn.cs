using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest01TrollSpawn : MonoBehaviour
{

    public GameObject spawnObject;
    public Transform spawnPoint;
    public Animator anim;

    private Quest01Starter Q01S;

    private bool spawned = false;

    void Start()
    {
        Q01S = FindObjectOfType<Quest01Starter>();
        anim.SetBool("canClose", false);
    }

    void Update()
    {
        if(Q01S.questCounter >= 1 && spawned == false)
        {
            SpawnTroll();
        }
    }

    public void SpawnTroll()
    {
        spawnObject.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        anim.SetBool("canClose", true);
        spawned = true;
    }
}
