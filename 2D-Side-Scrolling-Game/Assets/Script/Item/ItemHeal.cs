using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItemHeal", menuName = "Items/ItemHeal")]
public class ItemHeal : ItemSkill
{
    public float healAmount = 50f; // Amount of health to restore
    public override void UseSkill()
    {
        Debug.Log("Healing for " + healAmount + " health.");
    }

}
