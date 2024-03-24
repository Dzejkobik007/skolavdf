using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputText : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<InputText> { }

    const string styleSheetPath = "Default";
    const string ussInputText = "InputText";

    Label label = new Label(text: "Enter text");
    TextField input = new TextField();
    Button actionButton;
    public InputText()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(styleSheetPath));
        AddToClassList(ussInputText);
        actionButton = new Button() { text = "Confirm" };
        actionButton.clicked += ActionButtonClicked;
        Add(label);
        Add(input);
        Add(actionButton);
    }

    event Action buttonClicked;

    private void ActionButtonClicked()
    {
        buttonClicked?.Invoke();
    }
}