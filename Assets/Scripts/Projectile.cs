using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Flight")]
    public float speed;

    private ExplosionForce _force;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        _force = GetComponent<ExplosionForce>();
    }

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
        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Explodable>().explode();
            _force.doExplosion(transform.position);
        }
        
        Destroy(this.gameObject);
    }
}
