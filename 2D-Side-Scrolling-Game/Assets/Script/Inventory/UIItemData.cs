using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIItemData : MonoBehaviour
{
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI amountText;
    public Image itemIcon;
    public Image iconEqiup;
    public string itemID;

    public void SetItemData(ItemData itemData, ItemDataSO itemDataSO)
    {
        itemID = itemData.id;
        itemNameText.text = itemDataSO.itemName;
        amountText.text = itemData.amount.ToString() + "/" + itemDataSO.maxStack.ToString();
        itemIcon.sprite = itemDataSO.icon;
    }
    public void SetActiveIconEqiup(bool isActive)
    {
        iconEqiup.gameObject.SetActive(isActive);
    }
}
