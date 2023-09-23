using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{
    Waapon,
    Potion,
    Parchment,
    Treasure

}
public class InventoryItem : ScriptableObject {
   [Header("Parameters")]
   public string ID;
   public string Name;
   public Sprite Icon;
   [TextArea]public string Description;

    [Header("Information")]
    public ItemType Type;
    public bool IsConsumable;
    public bool IsCumulative;
    public int MaxAcumulation;

    [HideInInspector]public int Quantity;
}
