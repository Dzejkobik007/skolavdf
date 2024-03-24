using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    UIDocument ui;
    VisualElement root;
    InfoText infoText;
    MainMenu mainMenu;
    GameMenu gameMenu;
    SettingsMenu settingsMenu;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        ui = GetComponent<UIDocument>();
        root = ui.rootVisualElement;
        root.Add(infoText);
        infoText = new InfoText();
        mainMenu = new MainMenu();
        mainMenu.OnButtonPlayClicked += StartGame;
        mainMenu.OnButtonSettingsClicked += SettingsMenu;
        mainMenu.OnButtonQuitClicked += Application.Quit;
        settingsMenu = new SettingsMenu();
        settingsMenu.OnButtonBackClicked += () => { if (GameManager.Instance.GetState() == GameManager.State.MENU) { MainMenu(); } else { InGameMenu(); } };
        gameMenu = new GameMenu();
        gameMenu.OnButtonResumeClicked += () => { GameManager.Instance.SetState(GameManager.State.INGAME); UIReset(); };
        gameMenu.OnButtonSettingsClicked += SettingsMenu;
        gameMenu.OnButtonMainMenuClicked += () => { GameManager.Instance.SetState(GameManager.State.MENU); MainMenu(); };
        gameMenu.OnButtonQuitClicked += Application.Quit;
        GameManager.Instance.OnGameStateChanged += GameStateChanged;
        MainMenu();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && GameManager.Instance.GetState() == GameManager.State.INGAME) { InGameMenu(); }
    }

    public void StartGame()
    {
        GameManager.Instance.SetState(GameManager.State.INGAME);
    }

    public void GameStateChanged()
    {
        GameManager.State state = GameManager.Instance.GetState();
        if (state == GameManager.State.MENU)
        {
            MainMenu();
        } else
        {
            UIReset();
        }
    }

    public void ShowStatusText(string text)
    {
        if (text.Length < 1)
        {
            root.Remove(infoText);
            return;
        }
        infoText.SetText(text);
        root.Add(infoText);
    }

    public void MainMenu()
    {
        UIReset();
        root.Add(mainMenu);
    }

    public void InGameMenu()
    {
        UIReset();
        GameManager.Instance.SetState(GameManager.State.GAMEPAUSED);
        root.Add(gameMenu);
    }

    public void SettingsMenu()
    {
        UIReset();
        root.Add(settingsMenu);
    }

    public void UIReset()
    {
        root.Clear();
    }
}
