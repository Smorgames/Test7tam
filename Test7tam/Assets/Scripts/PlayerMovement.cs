using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string VerticalAxis = "Vertical";

    public Rigidbody2D Rigidbody;
    public float Speed;

    private Vector2 _inputAxis;

    private void Update() => 
        _inputAxis = new Vector2(Input.GetAxisRaw(HorizontalAxis), Input.GetAxisRaw(VerticalAxis)).normalized;

    private void FixedUpdate() => 
        Rigidbody.velocity = _inputAxis * Speed * Time.fixedDeltaTime;
}