using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float speedBoost = 5f;
    public float boostCooldown = 5f;
    public float boostDuration = 1f;

    public Rigidbody2D rb;

    Vector2 movement;
    bool boostFired;
    bool boosting;
    float boostCooldownInterval;
    float boostDurationInterval;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Boosting
        if (!boostFired && Input.GetButtonDown("Fire1"))
        {
            boostFired = true;
            boosting = true;
            boostCooldownInterval = Time.time + boostCooldown;
            boostDurationInterval = Time.time + boostDuration;
        }
        else if (boosting && Time.time > boostDurationInterval)
        {
            boosting = false;
        }
        else if (boostFired && Time.time > boostCooldownInterval)
        {
            boostFired = false;
        }
    }

    public Vector2 GetPlayerInput()
    {
        return movement;
    }

    void FixedUpdate()
    {
        if (boosting)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed + speedBoost) * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
