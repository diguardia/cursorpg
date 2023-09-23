using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    List<InventorySlot> availableSlots = new List<InventorySlot>();

    // Start is called before the first frame update
    void Start()
    {
        InitInventory();
    }

    private void InitInventory() {
        for (int i = 0; i<Inventory.Instance.SlotCount; i++) {
            InventorySlot slot = Instantiate(slotPrefab, container);
            slot.Index = i;
            availableSlots.Add(slot);
        }
    }
}
