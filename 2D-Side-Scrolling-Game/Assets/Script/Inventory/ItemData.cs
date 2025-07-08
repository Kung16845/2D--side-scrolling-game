using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class ItemDataSO : ScriptableObject
{
    public string itemName;
    public string id;
    public Sprite icon;
    public ItemType itemType;
    public int maxStack;
}
[System.Serializable]
public class ItemData
{   
    public string id;
    public int slotIndex;
    public int amount;
    public ItemData(string id, int slotIndex, int amount)
    {
        this.id = id;
        this.slotIndex = slotIndex;
        this.amount = amount;
    }
}
public enum ItemType
{
    Equippable,
    Usable,
    Placeable,
}
