using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible
{
    public int points { get; set; }

    public void OnCollected();
}
