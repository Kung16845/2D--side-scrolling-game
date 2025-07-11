using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimeHop : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            GameManager.Instance.TimeManager.TriggerNextTimePeriod();
        }
    }
}
