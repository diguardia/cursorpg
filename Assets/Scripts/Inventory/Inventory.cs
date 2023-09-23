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
    void Update()
    {
        
    }
}
