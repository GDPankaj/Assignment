using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour, ICollectible
{
    [SerializeField] int _points;
    public int points { get; set; }

    private void Start()
    {
        points = _points;
        GameManager.Instance.RegisterShape(this);
        // Example value
    }

    public void OnCollected()
    {
        GameEvents.Instance.ShapeCollected?.Invoke(points);
        GameManager.Instance.UnregisterShape(this);
        Destroy(gameObject); // Destroy the shape after collection
    }
}
