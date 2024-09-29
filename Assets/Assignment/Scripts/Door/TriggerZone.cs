using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField] int _triggerID;

    private void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameEvents.Instance.OnTriggerActivated?.Invoke(_triggerID);
        }
    }

    private void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.Instance.OnTriggerActive?.Invoke(_triggerID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.Instance.OnTriggerDeactivated?.Invoke(_triggerID);
        }
    }
}
