using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestHandler : MonoBehaviour
{
    public DialogManager dialogManager;
    public PlayerInventory playerInventory;

    public string[] Quest2, Quest3, Quest4, Quest5, OverD; // Quest1 is already handled in the QuestGiver GameObject

    internal string[] CurrentQuest;

    internal bool Quest1Done = false, Quest2Done = false, Quest3Done = false, Quest4Done = false, Quest5Done = false;

    void Start()
    {
        CurrentQuest = Quest2;
    }

    void Update()
    {
        if (playerInventory.SignCount >= 1 && Quest4Done)
        {
            Quest5Done = true;
        }
        if (playerInventory.FlowerCount >= 1 && Quest3Done)
        {
            Quest4Done = true;
        }
        if (playerInventory.SandCount >= 1 && Quest2Done)
        {
            Quest3Done = true;
        }
        if (playerInventory.GemCount >= 5 && Quest1Done)
        {
            Quest2Done = true;
        }
        if (playerInventory.CoinCount >= 5)
        {
            Quest1Done = true;
        }
    }

    public void QuestOrder()
    {
        if (Quest5Done && Quest4Done && playerInventory.SignCount >= 1)
        {
            CurrentQuest = OverD;
        }
        if (Quest4Done && Quest3Done && playerInventory.FlowerCount >= 1)
        {
            playerInventory.FlowerCount = 0;
            CurrentQuest = Quest5;
        }
        if (Quest3Done && Quest2Done && playerInventory.SandCount >= 1)
        {
            Debug.Log("This");
            playerInventory.SandCount = 0;
            CurrentQuest = Quest4;
        }
        if (Quest2Done && Quest1Done && playerInventory.GemCount >= 5)
        {
            playerInventory.GemCount = 0;
            CurrentQuest = Quest3;
        }
        if (Quest1Done && playerInventory.CoinCount >= 5)
        {
            playerInventory.CoinCount = 0;
            CurrentQuest = Quest2;
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
