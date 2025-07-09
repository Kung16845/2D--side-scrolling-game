using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public ItemData itemData;
    void OnTriggerStay2D(Collider2D collision)
    {

    }
    public void PickUp()
    {   
        Debug.Log("Picked up item: " + itemData.id);
        InventoryManager.Instance.AddItemByID(itemData.id,itemData.amount);
    }
}
