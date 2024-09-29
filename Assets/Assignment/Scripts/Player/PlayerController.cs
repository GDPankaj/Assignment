using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController
{
    private PlayerModel PlayerModel { get; }
    private PlayerView PlayerView { get; }

    private Rigidbody rb;
    private Vector3 _movementVelocity;
    public PlayerController(PlayerModel playerModel, PlayerView playerView)
    {
        PlayerView = playerView;
        PlayerModel = playerModel;
        PlayerModel.SetPlayerController(this);
        PlayerView.SetPlayerController(this);

        rb = PlayerView.Rigidbody;
    }


    public void HandleMovement(float x, float y,float z, float _cameraFollowRotation)
    {
        _movementVelocity = new Vector3(x, y, z);
        _movementVelocity.Normalize();
        _movementVelocity = Quaternion.Euler(0f, _cameraFollowRotation, 0f) * _movementVelocity;
        PlayerView.Animator.SetFloat("Speed", _movementVelocity.magnitude);
        rb.velocity = _movementVelocity * PlayerModel.Speed;

        if (_movementVelocity != Vector3.zero)
        {
            rb.rotation = Quaternion.LookRotation(_movementVelocity);
        }
    }

    public void Collected(Collider other)
    {
        ICollectible collectible = other.GetComponent<ICollectible>();
        if (collectible != null)
        {
            collectible.OnCollected();
        }
    }
}