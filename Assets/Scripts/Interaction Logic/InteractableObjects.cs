using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class InteractableObjects : MonoBehaviour
{
    public PlayerInventory PlayerInventory;

    private DialogManager dialogManager;

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
    public TextMeshProUGUI InfoText;

    [TextArea] public string[] Dialog;

    private void Awake()
    {
        dialogManager = GetComponent<DialogManager>();
    }

    private void Start()
    {
        InfoText.text = string.Empty;
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

        dialogManager.StartDialog(Dialog);
    }

    private void ClearMessage()
    {
        Debug.Log("Clearing message");

        InfoText.text = string.Empty;
    }
}
