using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGun_Enemy : MonoBehaviour
{
    private Guid id;
    private RPGun_FightManager manager;

    public void SetId(Guid id)
    {
        this.id = id;
    }

    public void SetFightManager(RPGun_FightManager manager)
    {
        this.manager = manager;
    }

    public void KillEnemy()
    {
        Debug.Log("killEnemyCalled");
        manager.RemoveEnemy(id);
    }
}
