using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    public float speed = 5f;

    public bool facingRight;

    void Awake()
    {
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

            if (angle > 0 && angle > 105)
            {
                facingRight = false;
            }
            else if (angle < 0 && angle < -82)
            {
                facingRight = false;
            }
        }
        else
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

            if (angle < 0 && angle < -105)
            {
                facingRight = true;
            }
            else if (angle > 0 && angle > 82)
            {
                facingRight = true;
            }
        }
  
    }

    public Vector3 GetRotation()
    {
        return transform.rotation.eulerAngles;
    }

    public bool GetFacingRight()
    {
        return facingRight;
    }
}
