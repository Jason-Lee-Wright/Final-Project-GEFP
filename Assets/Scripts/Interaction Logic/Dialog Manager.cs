using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    private Queue<string> Dialog;

    public GameObject DialogBox;
    public TextMeshProUGUI DialogueText;

    public bool DialoguePlaying = false;

    public PlayerMovement playerMovement;
    public PlayerInteract playerInteract;
    public GameStateManager gameStateManager;
    public PlayerInventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        Dialog = new Queue<string>();

        if (playerInteract == null)
        {
            GameObject playerObject = GameObject.FindWithTag("Player");
            if (playerObject != null)
            {
                playerInteract = playerObject.GetComponent<PlayerInteract>();
                playerMovement = playerObject.GetComponent<PlayerMovement>();
            }
        }
    }

    public void StartDialog(string[] sentances)
    {
        DialoguePlaying = true;
        Dialog.Clear();
        DialogBox.SetActive(true);

        foreach (string sentance in sentances)
        {
            Dialog.Enqueue(sentance);
        }

        NextInQueue();
    }

    public void NextInQueue()
    {
        if (Dialog.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            DialogueText.text = Dialog.Dequeue();
        }
    }

    void EndDialogue()
    {
        Dialog.Clear();
        DialogBox.SetActive(false);
        DialogueText.text = string.Empty;
        DialoguePlaying = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialoguePlaying)
        {
            PLayD();
        }
        else if (!DialoguePlaying && gameStateManager.currentState == GameStateManager.GameState.Gameplay_State)
        {
            EndD();
        }
    }

    void PLayD()
    {
        playerInteract.CanInteract = false;
        playerMovement.CanMove = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void EndD()
    {
        playerInteract.CanInteract = true;
        playerMovement.CanMove = true;
    }
}

public static class NextQuest
{
    public static Action QuestQueue;
}