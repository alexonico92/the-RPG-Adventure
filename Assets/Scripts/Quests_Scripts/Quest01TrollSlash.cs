using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest01TrollSlash : MonoBehaviour
{

    public Animator anim;
    public EnemyHealth_Manager EH_M;

    void Start()
    {
        anim.SetBool("canOpen", false);
    }


    void Update()
    {
        if(EH_M.CurrentHealth <= 0)
        {
            anim.SetBool("canOpen", true);
        }
    }
}
