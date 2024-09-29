using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    private PlayerController playerController;
    public float Speed { get; private set; }
    public PlayerModel(float speed)
    {
        Speed = speed;
    }

    public void SetPlayerController(PlayerController playerController)
    {
        this.playerController = playerController;
    }
}