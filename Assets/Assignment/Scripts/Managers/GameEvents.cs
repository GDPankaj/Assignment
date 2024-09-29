using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }

    public UnityEvent<int> OnTriggerActivated = new UnityEvent<int>();
    public UnityEvent<int> OnTriggerActive = new UnityEvent<int>();
    public UnityEvent<int> OnTriggerDeactivated = new UnityEvent<int>();
    public UnityEvent SpawnEnemy = new UnityEvent();
    public UnityEvent<int> ShapeCollected = new UnityEvent<int>();
    public UnityEvent AllShapesCollected = new UnityEvent();

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

    private void Start()
    {
        
    }
}
