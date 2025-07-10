using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    public ItemData itemData;
    public float holdTime = 0f;
    private float requiredHoldTime = 2f;
    public bool isPlayerNear = false;
    public Slider sliderHold;
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            isPlayerNear = true;
            sliderHold.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (isPlayerNear)
        {
            if (Input.GetKey(KeyCode.E))
            {
                holdTime += Time.deltaTime;
                sliderHold.value = holdTime / requiredHoldTime;
                if (holdTime >= requiredHoldTime)
                {
                    PickUp();
                    Destroy(gameObject);
                }
            }
            else
            {
                sliderHold.value = 0f;
                holdTime = 0f;
            }
        }
        else
        {
            holdTime = 0f;
            sliderHold.value = 0f;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        sliderHold.gameObject.SetActive(false);
        isPlayerNear = false;
 
    }
    public void PickUp()
    {
        Debug.Log("Picked up item: " + itemData.id);
        InventoryManager.Instance.AddItemByID(itemData.id, itemData.amount);
    }
}
