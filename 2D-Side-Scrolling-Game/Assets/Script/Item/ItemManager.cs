using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;
    [SerializeField] List<ItemSkill> itemSkills;
    [SerializeField] List<ItemEquip> itemEquips;
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
    public ItemEquip GetItemEquipByID(string itemId)
    {
        return itemEquips.Find(i => i.itemId == itemId);
     }
}
