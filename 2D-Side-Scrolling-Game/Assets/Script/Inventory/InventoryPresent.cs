using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPresent : MonoBehaviour
{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>();
    public int currentSlotIndex = 0;
    public float scrollCooldown = 0.5f;
    private float lastScrollTime = 0f;
    public UIItemData uiItemDataPrefab;
    private void Start()
    {
        RefreshUI();
    }
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (Mathf.Abs(scroll) > 0.05f && Time.time - lastScrollTime > scrollCooldown)
        {
            inventorySlots[currentSlotIndex].SetCurrentSlot(false);

            if (scroll > 0f)
            {
                currentSlotIndex++;
                if (currentSlotIndex >= inventorySlots.Count)
                    currentSlotIndex = 0;
            }
            else if (scroll < 0f)
            {
                currentSlotIndex--;
                if (currentSlotIndex < 0)
                    currentSlotIndex = inventorySlots.Count - 1;
            }

            inventorySlots[currentSlotIndex].SetCurrentSlot(true);
            lastScrollTime = Time.time;
        }
    }
    public int GetSlotEmptyIndex()
    {
        return inventorySlots.FindIndex(slot => slot.transform.childCount == 0);
    }
    public string GetCurrentUIItemDataID()
    {
        if (inventorySlots[currentSlotIndex].transform.childCount == 0)
        {
            Debug.LogWarning("No item data found in the current slot.");
            return null;
        }
        return inventorySlots[currentSlotIndex].GetComponentInChildren<UIItemData>().itemID;
    }
    [ContextMenu("RefreshUI")]
    public void RefreshUI()
    {   
        inventorySlots[currentSlotIndex].SetCurrentSlot(true);
        ClearUIItemsData();
        ItemData[] itemsDatas = InventoryManager.Instance.Inventory.ToArray();

        foreach (ItemData itemData in itemsDatas)
        {
            UIItemData uiItemData = Instantiate(uiItemDataPrefab, inventorySlots[itemData.slotIndex].transform);
            ItemDataSO itemDataSO = InventoryManager.Instance.GetItemByID(itemData.id);
            uiItemData.SetItemData(itemData, itemDataSO);
        }
    }
    [ContextMenu("ClearUIItemsData")]
    public void ClearUIItemsData()
    {
        foreach (var slot in inventorySlots)
        {
            UIItemData itemData = slot.GetComponentInChildren<UIItemData>();
            if (itemData != null)
            {
                Destroy(itemData.gameObject);
            }
        }
    }
}
