using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGun_FightManager : MonoBehaviour
{
    private Dictionary<Guid, RPGun_Enemy> enemies;
    private List<Transform> enemySpawnPoints;
    private RPGun_FightStage stage;

    private RPGun_GameManager manager;

    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RPGun_GameManager>();
        stage = manager.GetStage();
        var enemySpawnPointObjects = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        enemySpawnPoints = new List<Transform>();
        foreach (GameObject esp in enemySpawnPointObjects)
        {
            enemySpawnPoints.Add(esp.transform);
        }

        foreach (GameObject enemy in stage.enemiesToSpawn)
        {
            GameObject.Instantiate(enemy, enemySpawnPoints[0].position, enemySpawnPoints[0].rotation);
        }
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
