using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(OverheadCharacterAnimator))]
public class RPGun_Player : MonoBehaviour
{
    private bool canMove;

    private PlayerMovement movement;
    private OverheadCharacterAnimator animator;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        movement = this.GetComponent<PlayerMovement>();
        animator = this.GetComponent<OverheadCharacterAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StopMovement()
    {
        movement.StopMovement();
    }

    public void StartMovement()
    {
        movement.StartMovement();
    }
}
