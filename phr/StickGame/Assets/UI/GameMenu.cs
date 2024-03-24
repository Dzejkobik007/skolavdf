using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameMenu : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<GameMenu> { }

    const string defaultStyleSheetPath = "Default";
    const string ussGameContainer = "GameMenuContainer";

    public Label label = new Label() { text = "Game Menu" };
    public Button buttonResume = new AButton() { text = "Resume" };
    public Button buttonSettings = new AButton() { text = "Settings" };
    public Button buttonMainMenu = new AButton() { text = "MainMenu" };
    public Button buttonQuit = new AButton() { text = "Quit" };
    public GameMenu()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(defaultStyleSheetPath));

        VisualElement menuContainer = new VisualElement();
        AddToClassList(ussGameContainer);


        buttonResume.clicked += ButtonResumeClicked;
        buttonSettings.clicked += ButtonSettingsClicked;
        buttonMainMenu.clicked += ButtonMainMenuClicked;
        buttonQuit.clicked += ButtonQuitClicked;

        menuContainer.Add(label);
        menuContainer.Add(buttonResume);
        menuContainer.Add(buttonSettings);
        menuContainer.Add(buttonMainMenu);
        menuContainer.Add(buttonQuit);

        Add(menuContainer);
    }

    public event Action OnButtonResumeClicked;
    public event Action OnButtonSettingsClicked;
    public event Action OnButtonMainMenuClicked;
    public event Action OnButtonQuitClicked;
    private void ButtonResumeClicked()
    {
        OnButtonResumeClicked?.Invoke();
    }

    private void ButtonSettingsClicked()
    {
        OnButtonSettingsClicked?.Invoke();
    }

    private void ButtonMainMenuClicked()
    {
        OnButtonMainMenuClicked?.Invoke();
    }

    private void ButtonQuitClicked()
    {
        OnButtonQuitClicked?.Invoke();
    }
}