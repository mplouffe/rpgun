using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IndieMarc.TopDown;

public class RPGun_GameManager : MonoBehaviour
{
    private enum GameState
    {
        FIGHT,
        OVERWORLD,
        MENU
    }

    private GameState currentState;
    private List<GameState> previousStates;

    private RPGun_Player player;

    private bool statePaused;

    public GameObject overWorldPlayerPrefab;
    public GameObject fightPlayerPrefab;

    public GameObject fightEnemyPrefab;

    public List<Transform> playerSpawnPoints;

    private RPGun_FightStage stage;

    private static RPGun_GameManager Instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        currentState = GameState.OVERWORLD;
        stage = new RPGun_FightStage();
        stage.enemiesToSpawn = new List<GameObject>();
        stage.enemiesToSpawn.Add(fightEnemyPrefab);
    }

    // called first
    void OnEnable()
    {
        Debug.Log("OnEnable called");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        playerSpawnPoints = GetPlayerSpawnPoints();
        CheckForPlayer();
    }

    public void TriggerFight(RPGun_Enemy enemy)
    {
        StopPlayerMovement();
        SceneManager.LoadScene(1);
        player = null;
        currentState = GameState.FIGHT;
    }

    public void TriggerOverworld()
    {
        StopPlayerMovement();
        SceneManager.LoadScene(0);
        player = null;
        currentState = GameState.OVERWORLD;
    }

    private void CheckForPlayer()
    {
        if (currentState == GameState.OVERWORLD)
        {
            if (player == null) {
                ClearPlayerObjects();
                GameObject playerGameObject = GameObject.Instantiate(overWorldPlayerPrefab, playerSpawnPoints[0]);
                FollowCamera.Get().LockCameraOn(playerGameObject);
                player = playerGameObject.GetComponent<RPGun_Player>();
            }
        }
        else if (currentState == GameState.FIGHT)
        {
            if (player == null) {
                ClearPlayerObjects();
                GameObject playerGameObject = GameObject.Instantiate(fightPlayerPrefab, playerSpawnPoints[0]);
                FollowCamera.Get().LockCameraOn(playerGameObject);
            }


        }
    }

    private void ClearPlayerObjects()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = players.Length - 1; i >= 0; i--) {
            GameObject.Destroy(players[i]);
        }
    }

    private List<Transform> GetPlayerSpawnPoints()
    {
        List<Transform> returnList = new List<Transform>();
        var spawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");
        for (int i = 0; i < spawnPoints.Length; i++) {
            returnList.Add(spawnPoints[i].transform);
        }
        return returnList;
    }

    public void StopPlayerMovement()
    {
        if (player != null) {
            player.StopMovement();
        }
    }

    public void StartPlayerMovement()
    {
        player.StartMovement();
    }

    public RPGun_FightStage GetStage()
    {
        return stage;
    }
}
