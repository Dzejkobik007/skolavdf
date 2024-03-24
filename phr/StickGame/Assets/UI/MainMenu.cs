using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<MainMenu> { }

    const string defaultStyleSheetPath = "Default";
    const string ussMenuContainer = "MainMenu";

    public Image logo = new Image();
    public Button buttonPlay = new AButton() { text = "Play" };
    public Button buttonSettings = new AButton() { text = "Settings" };
    public Button buttonQuit = new AButton() { text = "Quit" };
    public MainMenu()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(defaultStyleSheetPath));

        VisualElement menuContainer = new VisualElement();
        AddToClassList(ussMenuContainer);

        //Label label = new Label() { text = "OOPS! Steam initialization failed" };
        //label.AddToClassList(ussLabel);
        Sprite imgLogo = Resources.Load<Sprite>("Sprites/MainMenuLogo");
        logo.sprite = imgLogo;
        Add(logo);


        buttonPlay.clicked += ButtonPlayClicked;
        buttonSettings.clicked += ButtonSettingsClicked;
        buttonQuit.clicked += ButtonQuitClicked;


        menuContainer.Add(buttonPlay);
        menuContainer.Add(buttonSettings);
        menuContainer.Add(buttonQuit);

        //Button retryButton = new AButton() { text = "Retry" };

        //retryButton.clicked += ButtonClickedRetry;
        //retryButton.AddToClassList(ussRetryButton);
        //Button offlineButton = new AButton() { text = "Play Local" };
        //offlineButton.clicked += ButtonClickedOffline;
        //offlineButton.AddToClassList(ussOfflineButton);

        //dialogContainer.Add(retryButton);
        //dialogContainer.Add(offlineButton);

        //buttonOne.clicked += ButtonOneClicked;
        //buttonTwo.clicked += ButtonTwoClicked;
        //dialogContainer.Add(buttonOne);
        //dialogContainer.Add(buttonTwo);

        Add(menuContainer);
    }

    public event Action OnButtonPlayClicked;
    public event Action OnButtonSettingsClicked;
    public event Action OnButtonQuitClicked;
    private void ButtonPlayClicked()
    {
        OnButtonPlayClicked?.Invoke();
    }

    private void ButtonSettingsClicked()
    {
        OnButtonSettingsClicked?.Invoke();
    }

    private void ButtonQuitClicked()
    {
        OnButtonQuitClicked?.Invoke();
    }
}