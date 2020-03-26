using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(OverheadEnemyAnimator))]
public class OverheadEnemyRandomMovement : MonoBehaviour
{
    private enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }

    public float moveSpeed;
    public float moveInterval;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Direction previousMovement;
    private bool collisionOnPreviousMove;
    private OverheadEnemyAnimator animator;

    private float nextMove;

    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<OverheadEnemyAnimator>();
        nextMove = Time.time + (moveInterval * Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        if (nextMove < Time.time) {
            List<Direction> legitDirections = new List<Direction>(){
                Direction.UP,
                Direction.DOWN,
                Direction.LEFT,
                Direction.RIGHT
            };

            if (collisionOnPreviousMove) {
                legitDirections.Remove(previousMovement);
            }

            int directionIndex = Random.Range(0, legitDirections.Count);
            Direction direction = legitDirections[directionIndex];

            switch (direction) {
                case Direction.UP:
                    movement = new Vector2(0, 1);
                    break;
                case Direction.RIGHT:
                    movement = new Vector2(1, 0);
                    break;
                case Direction.LEFT:
                    movement = new Vector2(0, -1);
                    break;
                case Direction.DOWN:
                    movement = new Vector2(-1, 0);
                    break;
                default:
                    movement = new Vector2(0, 0);
                    break;
            }

            collisionOnPreviousMove = false;
            animator.SetMovement(movement);
            previousMovement = direction;
            nextMove = Time.time + moveInterval;
        }
    }

    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (!collisionOnPreviousMove) {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        collisionOnPreviousMove = true;   
    }
}
