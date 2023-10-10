using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int slotCount;
    public int SlotCount => slotCount;

    [Header("Items")]
    [SerializeField] private InventoryItem[] inventoryItems;

    // Start is called before the first frame update
    void Start()
    {
        inventoryItems = new InventoryItem[slotCount];
    }

    // Update is called once per frame
    private void AddItem(InventoryItem itemToAdd, int quantity) 
    {
        if (itemToAdd == null) { return;}

    }

    private List<int> VerifyExistences(string itemId) {
        var itemIdexes = new List<int>();
        for (int i = 0; i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i].ID == itemId)
            {
                itemIdexes.Add(i);
            }
        }

        return itemIdexes;
    }
}
