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
        enemies = new Dictionary<Guid, RPGun_Enemy>();
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
            GameObject newObject = GameObject.Instantiate(enemy, enemySpawnPoints[0].position, enemySpawnPoints[0].rotation);
            RPGun_Enemy newEnemy = newObject.GetComponent<RPGun_Enemy>();
            newEnemy.SetId(AddEnemy(newEnemy));
            newEnemy.SetFightManager(this);
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
        Debug.Log("Remove Enemies Called");
        enemies.Remove(id);
        Debug.Log("count: " + enemies.Count);
        if (enemies.Count == 0)
        {
            Debug.Log("Calling EndScene...");
            StartCoroutine(EndScene());
        }
    }

    public IEnumerator EndScene()
    {
        Debug.Log("EndSceneCalled..");
        yield return new WaitForSeconds(2);
        Debug.Log("Waited for 2 second...");
        manager.TriggerOverworld();
    }
}
