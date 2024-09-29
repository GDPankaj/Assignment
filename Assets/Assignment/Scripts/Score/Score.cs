using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int _Score { get; private set; }

    private void Awake()
    {
        _Score = 0;
    }
    public void AddScore(int points)
    {
        _Score += points;
    }
}
