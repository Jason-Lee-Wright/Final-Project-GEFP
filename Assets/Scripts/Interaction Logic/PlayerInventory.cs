using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI Inventory; // this will simulate an inventory for now.

    [SerializeField]
    private int GemCount = 0, CoinCount = 0;
    private int LastGemCount, LastCoinCount;

    private void Start()
    {
        ResetInventory();
        UpdateInventory();
    }

    public void CollectItem(string Item)
    {
        if (Item == "Gem")
        {
            GemCount++;
            Debug.Log(GemCount);
            UpdateInventory();
        }
        if (Item == "Coin")
        {
            CoinCount++;
            Debug.Log(CoinCount);
            UpdateInventory();
        }
    }

    void UpdateInventory()
    {
        Inventory.text = "Inventory";

        if (GemCount > 0)
        {
            Inventory.text += $"\nGems: {GemCount}";
        }

        if (CoinCount > 0)
        {
            Inventory.text += $"\nCoins: {CoinCount}";
        }
    }

    private void ResetInventory()
    {
        GemCount = 0;
        CoinCount = 0;
    }

    private void Update()
    {
        if (LastGemCount != GemCount || LastCoinCount != CoinCount)
        {
            UpdateInventory();
        }
    }
}
