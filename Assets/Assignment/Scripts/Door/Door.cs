using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Door : MonoBehaviour, ITriggerable
{
    [SerializeField] int _doorId;
    Animator _doorAnimator;

    private void OnEnable()
    {
        GameEvents.Instance.OnTriggerActivated.AddListener(OpenDoor);
        GameEvents.Instance.OnTriggerDeactivated.AddListener(CloseDoor);
    }

    private void OnDisable()
    {
        GameEvents.Instance.OnTriggerActivated.RemoveListener(OpenDoor);
        GameEvents.Instance.OnTriggerDeactivated.RemoveListener(CloseDoor);
    }

    private void Start()
    {
        _doorAnimator = GetComponent<Animator>();

        Debug.Log($"Door ID is {_doorId} this is from door script");
    }

    private void OpenDoor(int doorID)
    {
        if (doorID == _doorId)
        {
            _doorAnimator.SetBool("Closed", false);
        }
    }

    private void CloseDoor(int doorID)
    {
        if (doorID == _doorId)
        {
            _doorAnimator.SetBool("Closed", true);
        }
    }

    public void OnTriggerActivated(int triggerID)
    {
        OpenDoor(triggerID);
    }

    public void OnTriggerActive(int triggerID)
    {
        throw new System.NotImplementedException();
    }

    public void OnTriggerDeactivated(int triggerID)
    {
        CloseDoor(triggerID);
    }
}
