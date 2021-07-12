using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int maxLives;
    public int currentLives;

    public Image resIcon1;
    public Image resIcon2;
    public Image resIcon3;
    public Image resIcon4;
    public Image resIcon5;

    void Update()
    {
        if(currentLives < 1)
        {
            resIcon1.enabled = false;
            resIcon2.enabled = false;
            resIcon3.enabled = false;
            resIcon4.enabled = false;
            resIcon5.enabled = false;
            Debug.Log("You Lose!!!"); //daj tu ekran śmierci i napis GAME OVER
        }

        if(currentLives == 1)
        {
            resIcon1.enabled = true;
            resIcon2.enabled = false;
            resIcon3.enabled = false;
            resIcon4.enabled = false;
            resIcon5.enabled = false;
        }

        if (currentLives == 2)
        {
            resIcon1.enabled = true;
            resIcon2.enabled = true;
            resIcon3.enabled = false;
            resIcon4.enabled = false;
            resIcon5.enabled = false;
        }

        if (currentLives == 3)
        {
            resIcon1.enabled = true;
            resIcon2.enabled = true;
            resIcon3.enabled = true;
            resIcon4.enabled = false;
            resIcon5.enabled = false;
        }

        if (currentLives == 4)
        {
            resIcon1.enabled = true;
            resIcon2.enabled = true;
            resIcon3.enabled = true;
            resIcon4.enabled = true;
            resIcon5.enabled = false;
        }

        if (currentLives == 5)
        {
            resIcon1.enabled = true;
            resIcon2.enabled = true;
            resIcon3.enabled = true;
            resIcon4.enabled = true;
            resIcon5.enabled = true;
        }
    }

    public void TakeLive(int liveToTake)
    {
        currentLives -= liveToTake;
    }
}
