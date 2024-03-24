using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsMenu : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<SettingsMenu> { }

    const string defaultStyleSheetPath = "Default";
    const string ussMenuContainer = "SettingsContainer";


    Resolution[] resolutions;
    public DropdownField dropdownFieldRes;
    public DropdownField dropdownFieldScreenMode = new DropdownField("Screen Mode", new List<string>() { "Windowed", "Fullscreen" }, 0);
    public Slider sliderMaster = new Slider { label = "Master Volume", lowValue = 0f, highValue = 200f, value = 100f };
    public Button buttonBack = new AButton() { text = "Back" };
    public SettingsMenu()
    {
        // Resolutions dropdown

        resolutions = Screen.resolutions;
        List<string> options = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[(resolutions.Length - 1) - i].width + "x" + resolutions[(resolutions.Length - 1) - i].height;
            options.Add(option);
            if (resolutions[(resolutions.Length - 1) - i].width == Screen.currentResolution.width && resolutions[(resolutions.Length - 1) - i].height == Screen.currentResolution.height) { 
                currentResIndex = i;
            }
        }

        dropdownFieldRes = new DropdownField("Resolutions", options, 0);
        dropdownFieldRes.index = currentResIndex;
        styleSheets.Add(Resources.Load<StyleSheet>(defaultStyleSheetPath));

        VisualElement menuContainer = new VisualElement();
        menuContainer.AddToClassList(ussMenuContainer);

        dropdownFieldRes.RegisterValueChangedCallback(evt => DropDownChangedRes());
        dropdownFieldScreenMode.RegisterValueChangedCallback(evt => DropDownChangedScreen()); ;
        sliderMaster.RegisterValueChangedCallback(evt => SliderMasterValueChanged());
        buttonBack.clicked += ButtonBackClicked;

        menuContainer.Add(dropdownFieldRes);
        menuContainer.Add(dropdownFieldScreenMode);
        menuContainer.Add(sliderMaster);
        menuContainer.Add(buttonBack);

        Add(menuContainer);
    }

    public event Action OnDropdownChangedResolution;
    public event Action OnDropdownChangedScreenMode;
    public event Action OnSliderMasterChanged;
    public event Action OnButtonBackClicked;

    private void DropDownChangedRes()
    {
        OnDropdownChangedResolution?.Invoke();
    }

    private void DropDownChangedScreen()
    {
        OnDropdownChangedScreenMode?.Invoke();
    }

    private void SliderMasterValueChanged()
    {
        OnSliderMasterChanged?.Invoke();
    }

    public float GetSliderMasterValue()
    {
        return (float)sliderMaster.value;
    }

    private void ButtonBackClicked()
    {
        OnButtonBackClicked?.Invoke();
    }
}