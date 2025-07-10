using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{   
    public static GameManager Instance;
    [SerializeField] TimeManager timeManager;
    public TimeManager TimeManager => timeManager;
    [SerializeField] private PlayerController player;
    public PlayerController Player => player;
    [SerializeField] private Transform playerSpawnPoint;
    public Transform PlayerSpawnPoint => playerSpawnPoint;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
