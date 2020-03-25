using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldMoveToPlayer : MonoBehaviour
{

    public OverheadEnemyAnimator selfAnimationControllerScript;

    private Vector2 enemyMovement;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // detect player and determine the direction of the next step
        selfAnimationControllerScript.SetMovement(enemyMovement);
    }

    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        
    }
}
