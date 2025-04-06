using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogManager : MonoBehaviour
{
    private Queue<string> Dialog;

    public GameObject DialogBox;
    public TextMeshProUGUI DialogueText;

    public bool DialoguePlaying = false;

    public PlayerMovement playerMovement;
    public PlayerInteract playerInteract;

    // Start is called before the first frame update
    void Start()
    {
        Dialog = new Queue<string>();
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
    }

    // Update is called once per frame
    void Update()
    {
        if (DialoguePlaying)
        {
            playerInteract.CanInteract = false;
        }
        else
        {
            playerInteract.CanInteract = true;
        }
    }
}
