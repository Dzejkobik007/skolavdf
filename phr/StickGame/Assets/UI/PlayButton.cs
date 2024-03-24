using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayButton : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<PlayButton> { }

    const string styleSheetPath = "Default";
    const string ussActionButton = "PlayButton";
    public PlayButton()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(styleSheetPath));
        AddToClassList(ussActionButton);
        Button actionButton = new Button() { text = "Play" };
        actionButton.clicked += ActionButtonClicked;
        Add(actionButton);
    }

    private void ActionButtonClicked()
    {
        
    }
}