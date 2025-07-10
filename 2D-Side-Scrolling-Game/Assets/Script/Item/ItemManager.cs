using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    [SerializeField] List<ItemSkill> itemSkills;
    [SerializeField] List<ItemEquip> itemEquips;
    [SerializeField] List<ItemPlaceable> itemPlaceables;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UseItemSkill(string itemId)
    {
        ItemSkill itemSkill = itemSkills.Find(skill => skill.itemId == itemId);
        if (itemSkill != null)
        {
            itemSkill.UseSkill();
        }
    }
    public void PlaceItem(string itemId)
    {
        ItemPlaceable itemPlaceable = itemPlaceables.Find(i => i.itemId == itemId);
        if (itemPlaceable != null)
        {
            itemPlaceable.PlaceItem();
        }
    }
    public ItemEquip GetItemEquipByID(string itemId)
    {
        return itemEquips.Find(i => i.itemId == itemId);
    }
    public ItemPlaceable GetItemPlaceableByID(string itemId)
    {
        return itemPlaceables.Find(i => i.itemId == itemId);
    }

}
