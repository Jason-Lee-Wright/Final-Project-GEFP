using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public DialogManager dialogManager;
    public PlayerInventory playerInventory;

    public string[] Quest2, Quest3, Quest4, Quest5; // Quest1 is already handled in the QuestGiver GameObject

    private bool Quest1Done = false, Quest2Done = false, Quest3Done = false, Quest4Done = false, Quest5Done = false;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void QuestOrder()
    {
        if (!Quest5Done && Quest4Done)
        {
            Quest5Done = true;
        }
        if (!Quest4Done && Quest3Done)
        {
            Quest4Done = true;
        }
        if (!Quest3Done && Quest2Done)
        {
            Quest3Done = true;
        }
        if (!Quest2Done && Quest1Done)
        {
            Quest2Done = true;
        }
        if (!Quest1Done)
        {
            Quest1Done = true;
        }
    }

    private void OnEnable()
    {
        NextQuest.QuestQueue += QuestOrder;
    }

    private void OnDisable()
    {
        NextQuest.QuestQueue -= QuestOrder;
    }
}
