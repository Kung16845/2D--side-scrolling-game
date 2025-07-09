using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image BgSlot;
    public int slotIndex;
    public void SetCurrentSlot(bool isSelected)
    {
        BgSlot.color = isSelected ? Color.green : Color.white;
    }
}
