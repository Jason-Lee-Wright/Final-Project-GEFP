using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public TextMeshProUGUI Inventory; // this will simulate an inventory for now.

    [SerializeField]
    internal int GemCount = 0, CoinCount = 0, SandCount = 0, FlowerCount = 0, SignCount = 0;
    private int LastGemCount, LastCoinCount, LastSnadCount, LastFlowerCount, LastSignCount;

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
            LastGemCount = GemCount;
            UpdateInventory();
        }
        if (Item == "Coin")
        {
            CoinCount++;
            LastCoinCount = CoinCount;
            UpdateInventory();
        }
        if (Item == "Sand")
        {
            SandCount++;
            LastSnadCount = SandCount;
            UpdateInventory();
        }
        if (Item == "Flower")
        {
            FlowerCount++;
            LastFlowerCount = FlowerCount;
            UpdateInventory();
        }
        if (Item == "Sign")
        {
            SignCount++;
            LastSignCount = SignCount;
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

        if (SandCount > 0)
        {
            Inventory.text += $"\nSand: {SandCount}";
        }

        if (FlowerCount > 0)
        {
            Inventory.text += $"\nFlowers: {FlowerCount}";
        }
        if (SignCount > 0)
        {
            Inventory.text += $"\nSigns: {SignCount}";

        }
    }

    private void ResetInventory()
    {
        GemCount = 0;
        CoinCount = 0;
    }

    private void Update()
    {
        if (LastGemCount != GemCount || LastCoinCount != CoinCount || LastSnadCount != SandCount)
        {
            UpdateInventory();
        }
    }
}
