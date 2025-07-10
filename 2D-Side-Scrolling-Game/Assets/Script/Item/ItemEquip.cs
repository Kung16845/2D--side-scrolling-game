using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEquip : ScriptableObject
{
    public string itemId;
    public virtual void EquipItem() { }
    public virtual void RemoveEquipItem() { }
}
