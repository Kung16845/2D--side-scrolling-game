using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] List<ItemDataSO> allItems = new List<ItemDataSO>();
    [SerializeField] private List<ItemData> inventory = new List<ItemData>();
    public List<ItemData> Inventory => inventory;
    [SerializeField] InventoryPresent inventoryPresent;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }
    }
    public void UseItem()
    {
        string itemId = inventoryPresent.GetCurrentUIItemDataID();
        if (itemId == null)
        {
            return;
        }
        ItemData item = inventory.Find(i => i.id == itemId);
        ItemDataSO itemDataSO = GetItemByID(itemId);
        if (itemDataSO.itemType == ItemType.Usable)
        {
            Debug.Log("Using item: " + itemDataSO.itemName);
            RemoveItemByID(itemId);
        }
        else
        {
            Debug.Log("Item is not usable: " + itemDataSO.itemName);
        }
    }
    public void AddItemByID(string itemId, int amount = 1)
    {

        ItemData item = inventory.Find(i => i.id == itemId);
        if (item != null)
        {
            if (item.amount + amount > GetItemByID(itemId).maxStack)
            {
                if (inventory.Count >= inventoryPresent.inventorySlots.Count)
                {
                    Debug.LogWarning("Inventory is full, cannot add more items.");
                    return;
                }
                item.amount = GetItemByID(itemId).maxStack;
                int slotIndex = inventoryPresent.GetSlotEmptyIndex();
                ItemData newItem = new ItemData(itemId, slotIndex, amount - (GetItemByID(itemId).maxStack - item.amount));
                inventory.Add(newItem);
            }
            else
            {
                item.amount += amount;
            }
        }
        else
        {
            if (inventory.Count >= inventoryPresent.inventorySlots.Count)
            {
                Debug.LogWarning("Inventory is full, cannot add more items.");
                return;
            }
            ItemDataSO itemDataSO = allItems.Find(i => i.id == itemId);
            if (amount > itemDataSO.maxStack)
            {
                amount = itemDataSO.maxStack;
            }
            int slotIndex = inventoryPresent.GetSlotEmptyIndex();
            item = new ItemData(itemDataSO.id, slotIndex, amount);
            inventory.Add(item);
        }
        inventoryPresent.RefreshUI();
    }
    public void RemoveItemByID(string itemId, int amount = 1)
    {
        int slotIndex = inventoryPresent.currentSlotIndex;
        ItemData item = inventory.Find(i => i.id == itemId && i.slotIndex == slotIndex);
        if (item != null)
        {
            item.amount -= amount;
            if (item.amount <= 0)
            {
                inventory.Remove(item);
            }
        }
        inventoryPresent.RefreshUI();

    }
    public ItemDataSO GetItemByID(string itemId)
    {
        return allItems.Find(i => i.id == itemId);
    }
}
