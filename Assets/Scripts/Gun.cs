using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun")]
    public Transform bulletSpawn;
    public float coolDown;

    [Header("Ammo")]
    public GameObject bullet;
    public int magazine;
    public float reloadTime;

    public GameObject gunArms;

    private List<Projectile> projectiles;
    private float offCooldown;

    public void Shoot()
    {
        if (!IsEmpty() && IsOffCooldown())
        {
            FireGun();
        }
        else
        {
            TriggerClick();
        }
    }

    private void FireGun()
    {
        GameObject firedBullet = Instantiate(bullet, bulletSpawn.position, gunArms.transform.rotation) as GameObject;
        Projectile firedProjectile = firedBullet.GetComponent<Projectile>();
        firedProjectile.Fire();
        offCooldown = Time.time + coolDown;
    }

    private void TriggerClick()
    {
        Debug.Log("Click...");
    }

    private bool IsEmpty()
    {
        return magazine <= 0;
    }

    private bool IsOffCooldown()
    {
        return offCooldown < Time.time;
    }
}
