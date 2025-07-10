using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemScroll", menuName = "Items/ItemScroll")]

public class ItemScroll : ItemEquip
{
    public float attack;
    public override void EquipItem()
    {
        GameManager.Instance.Player.IncreaseDamage(attack);
    }
    public override void RemoveEquipItem()
    {
        GameManager.Instance.Player.DecreaseDamage(attack);
    }
}
