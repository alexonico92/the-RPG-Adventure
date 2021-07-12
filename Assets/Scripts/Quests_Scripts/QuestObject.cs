using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{

    public int questNumber;

    public QuestManager theQM;

    public string startText;
    public string endText;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartQuest()
    {
        theQM.ShowQuestText(startText);
    }

    public void EndQuest()
    {
        theQM.ShowQuestText(endText);
        theQM.questCompleted[questNumber] = true;
        gameObject.SetActive(false);
    }
}
