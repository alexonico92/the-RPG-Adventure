using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public void LoadStartLevel()
    {
        Application.LoadLevel("Level_01");
    }

    public void LoadControlsLevel()
    {
        Application.LoadLevel("ControlsMenu");
    }
}
