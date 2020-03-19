using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Flight")]
    public float speed;

    public List<Projectile> Fire()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.right * speed);
        return new List<Projectile>{ this };
    }
    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Sanity check");
        Destroy(this.gameObject);
    }
}
