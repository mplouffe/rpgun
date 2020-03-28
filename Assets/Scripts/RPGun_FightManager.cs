using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGun_FightManager : MonoBehaviour
{
    private Dictionary<Guid, RPGun_Enemy> enemies;

    private RPGun_GameManager manager;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RPGun_GameManager>();
    }

    public Guid AddEnemy(RPGun_Enemy enemy)
    {
        Guid id = new Guid();
        enemies.Add(id, enemy);
        return id;
    }

    public void RemoveEnemy(Guid id)
    {
        enemies.Remove(id);
        if (enemies.Count == 0)
        {
            manager.TriggerOverworld();
        }
    }
}
