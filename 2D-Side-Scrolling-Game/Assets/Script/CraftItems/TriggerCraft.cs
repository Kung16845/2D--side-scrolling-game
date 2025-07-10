using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCraft : MonoBehaviour
{
    public GameObject uICraft;
    public bool isPlayerNear;
    private void Start()
    {
        uICraft = CraftManager.Instance.uICraft;
    }
    void Update()
    {
        if (!isPlayerNear) return;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (uICraft.activeSelf) uICraft.SetActive(false);
            else uICraft.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            isPlayerNear = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerNear = false;
    }
}
