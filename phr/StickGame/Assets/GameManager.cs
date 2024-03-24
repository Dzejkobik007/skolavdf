using System;
using System.Linq;
//using FishNet.Managing.Scened;
using UnityEngine.SceneManagement;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public bool steamEnabled = false;

    [SyncObject]
    public readonly SyncList<Player> players = new();

    [SyncVar]
    public bool canStart;
    [SerializeField] [SyncVar]
    State activeState = State.NONE;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //this.Despawn();
            Destroy(this);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        SetState(State.MENU);
        
    }

    void Update()
    {
        //if (!IsServer) return;

        canStart = players.All(player => player.isReady);
    }

    public Action OnGameStateChanged;
    //[ServerRpc]
    public void SetState(State state)
    {

        switch (state)
        {
            case State.MENU:
                Debug.Log("Starting game manager");
                if (activeState == State.MENU)
                {
                    break;
                }
                Debug.Log("Entering MENU");
                activeState = State.MENU;
                OnGameStateChanged?.Invoke();
                SceneManager.LoadScene("Bootstrap");
                //SceneLoadData menuScene = new SceneLoadData("MenuScene");
                //SceneManager.LoadGlobalScenes(menuScene);
                break;
            case State.INGAME:
                if (activeState == State.INGAME)
                {
                    break;
                }
                if (activeState == State.GAMEPAUSED)
                {
                    Debug.Log("Resuming game...");
                    Time.timeScale = 1;
                    activeState = State.INGAME;
                    break;
                }
                Debug.Log("Entering in GAME");
                activeState = State.INGAME;
                OnGameStateChanged?.Invoke();
                SceneManager.LoadScene("SampleScene");
                //SceneLoadData gameScene = new SceneLoadData("GameScene");
                //SceneManager.LoadGlobalScenes(gameScene);
                break;
            case State.GAMEPAUSED:
                Debug.Log("Pausing...");
                Time.timeScale = 0;
                activeState = State.GAMEPAUSED;
                OnGameStateChanged?.Invoke();
                break;
            default:
                Debug.LogError("Invalid state");
                break;
        }
    }

    public State GetState() { return activeState; }

    public enum State
    {
        NONE,
        MENU,
        INGAME,
        GAMEPAUSED
    }
}
