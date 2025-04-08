using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class InteractableObjects : MonoBehaviour
{
    public PlayerInventory PlayerInventory;

    public QuestHandler questHandler;

    private DialogManager dialogManager;

    public string ItemID;

    public enum TypeInteract
    {
        Blank,
        Pickup,
        Info,
        Dialogue
    }

    [Header("Type of Interactable")]
    public TypeInteract interType;


    [Header("Info Area")]
    public string message; // Custom message shown when interacted with
    public TextMeshPro InfoText;

    [TextArea] public string[] Dialog;

    private void Awake()
    {

    }

    private void Start()
    {
        InfoText = GameObject.FindGameObjectWithTag("InfoText").GetComponent<TextMeshPro>();

        PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        dialogManager = GameObject.FindGameObjectWithTag("DioManager").GetComponent<DialogManager>();

        questHandler = GameObject.FindGameObjectWithTag("QuestHandler").GetComponent<QuestHandler>();

        InfoText.text = string.Empty;

        if (GameFlags.CollectedItems.Contains(ItemID))
        {
            gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        switch (interType)
        {
            case TypeInteract.Pickup:
                Pickup();
                break;
            case TypeInteract.Info:
                Info();
                break;
            case TypeInteract.Dialogue:
                Dialogue();
                break;
            default:
                Blank();
                break;
        }
    }

    public void Blank()
    {
        Debug.Log("Interaction type not defined for: " + gameObject.name);
    }

    public void Pickup()
    {
        PlayerInventory.CollectItem(this.gameObject.name);

        GameFlags.CollectedItems.Add(ItemID);

        this.gameObject.SetActive(false);
    }

    public void Info()
    {
        CancelInvoke();
        InfoText.text = string.Empty;
        InfoText.text = message;
        Invoke("ClearMessage", 5);
    }

    public void Dialogue()
    {
        Debug.Log("Starting dialogue with: " + gameObject.name);

        questHandler.QuestOrder();

        if (!questHandler.Quest1Done)
        {
            dialogManager.StartDialog(Dialog);
        }
        else
        {
            dialogManager.StartDialog(questHandler.CurrentQuest);
        }
    }

    private void ClearMessage()
    {
        Debug.Log("Clearing message");

        InfoText.text = string.Empty;
    }
}

public static class GameFlags
{
    public static HashSet<string> CollectedItems = new HashSet<string>();
}