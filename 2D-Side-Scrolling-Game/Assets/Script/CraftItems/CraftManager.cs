using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CraftManager : MonoBehaviour
{
    public List<CraftRecipe> craftRecipes;
    public static CraftManager Instance;
    public GameObject uICraft;
    public string currentCraftRecipeID;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (uICraft.activeSelf) uICraft.SetActive(false);
            else uICraft.SetActive(true);    
        }
    }
    public void SetCurrentCraftRecipeID(UICraft uICraft)
    {
        currentCraftRecipeID = uICraft.craftRecipeID;
    }
    public void CraftItemCurrentcraftRecipeID()
    {
        if (currentCraftRecipeID == "") return;
        CraftRecipe craftRecipe = GetCraftRecipeByID(currentCraftRecipeID);
        List<ItemData> inventory = InventoryManager.Instance.Inventory;
        if (HasAllMaterials(craftRecipe, inventory))
        {
            foreach (var item in craftRecipe.itemMetairieIDs)
            {
                InventoryManager.Instance.RemoveItemByID(item.itemMetairieID, item.countPerOne);
            }
            InventoryManager.Instance.AddItemByID(craftRecipe.itemCraftID);
        }
        else
        {
            Debug.Log("Cannot Craft Items");
        }
    }
    public bool HasAllMaterials(CraftRecipe recipe, List<ItemData> inventory)
    {
        foreach (var material in recipe.itemMetairieIDs)
        {
            int total = 0;
            foreach (var item in inventory)
            {
                if (item.id == material.itemMetairieID)
                {
                    total += item.amount;
                }
            }
            if (total < material.countPerOne)
                return false;
        }
        return true;
    }

    public CraftRecipe GetCraftRecipeByID(string craftRecipeID)
    {
        return craftRecipes.Find(item => item.craftRecipeID == craftRecipeID);
    }
}
[Serializable]
public class CraftRecipe
{
    public string craftRecipeID;
    public List<ItemMetairieID> itemMetairieIDs;
    public string itemCraftID;
}
[Serializable]
public class ItemMetairieID
{
    public string itemMetairieID;
    public int countPerOne;
}
