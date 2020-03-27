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

    private bool canMove;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        canMove = true;    
    }

    void Update()
    {
        if (canMove) {
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
    }

    public void StopMovement()
    {
        canMove = false;
    }

    public void StartMovement()
    {
        canMove = true;
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

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log ("Sanity Check");
        if (other.gameObject.tag == "OverworldEnemy")
        {
            RPGun_GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RPGun_GameManager>();
            manager.TriggerFight(other.gameObject.GetComponent<RPGun_Enemy>());
        }
    }
}
