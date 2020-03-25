using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadEnemyAnimator : MonoBehaviour
{
    public enum DirectionFacing
    {
        UP,
        RIGHT,
        LEFT,
        DOWN
    }
    
    public Animator animator;

    private DirectionFacing currentDirection;
    private Vector3 startScale;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentDirection = DirectionFacing.DOWN;
        startScale = transform.localScale;
    }

    public void SetMovement(Vector2 movement)
    {
        this.movement = movement;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (movement.magnitude == 0)
        {
            return;            
        }

        if (movement.x * movement.x > movement.y * movement.y)
        {
            if (movement.x < 0 && currentDirection != DirectionFacing.LEFT)
            {
                ChangeDirection(DirectionFacing.LEFT);
            }
            else if (movement.x > 0 && currentDirection != DirectionFacing.RIGHT)
            {
                ChangeDirection(DirectionFacing.RIGHT);
            }
        }
        else
        {
            if (movement.y < 0 && currentDirection != DirectionFacing.DOWN)
            {
                ChangeDirection(DirectionFacing.DOWN);
            }
            else if (movement.y > 0 && currentDirection != DirectionFacing.UP)
            {
                ChangeDirection(DirectionFacing.UP);
            }
        } 
    }

    public void ChangeDirection(DirectionFacing newDirection)
    {
        if (newDirection == currentDirection)
            return;

        switch (currentDirection) {
            case DirectionFacing.UP:
                animator.ResetTrigger("Up");
                break;
            case DirectionFacing.LEFT:
                animator.ResetTrigger("Left");
                break;
            case DirectionFacing.RIGHT:
                animator.ResetTrigger("Right");
                break;
            default:
                animator.ResetTrigger("Down");
                break;
        }

        switch (newDirection) {
            case DirectionFacing.UP:
                OnFaceUp();
                break;
            case DirectionFacing.LEFT:
                OnFaceLeft();
                break;
            case DirectionFacing.RIGHT:
                OnFaceRight();
                break;
            default:
                OnFaceDown();
                break;
        }
    }

    void OnFaceUp()
    {
        currentDirection = DirectionFacing.UP;
        animator.SetTrigger("Up");
    }

    void OnFaceDown()
    {
        currentDirection = DirectionFacing.DOWN;
        animator.SetTrigger("Down");
    }

    void OnFaceRight()
    {
        currentDirection = DirectionFacing.RIGHT;
        animator.SetTrigger("Right");
    }

    void OnFaceLeft()
    {
        currentDirection = DirectionFacing.LEFT;
        animator.SetTrigger("Left");
    }
}
