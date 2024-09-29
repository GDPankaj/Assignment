using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerable
{ 
    void OnTriggerActivated(int triggerID);
    void OnTriggerActive(int triggerID);
    void OnTriggerDeactivated(int triggerID);
}
