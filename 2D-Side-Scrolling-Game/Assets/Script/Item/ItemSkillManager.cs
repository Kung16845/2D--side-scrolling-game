using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSkillManager : MonoBehaviour
{
    public static ItemSkillManager Instance;
    [SerializeField] List<ItemSkill> itemSkills;
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
}
