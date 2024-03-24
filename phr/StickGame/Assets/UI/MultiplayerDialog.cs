using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MultiplayerDialog : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<MultiplayerDialog> { }

    const string defaultStyleSheetPath = "Default";
    const string styleSheetPath = "MultiplayerDialog";
    const string ussLabel = "Label";
    const string ussDialogContainer = "MultiplayerDialog";
    const string ussRetryButton = "RetryButton";
    const string ussOfflineButton = "RetryButton";
    public MultiplayerDialog()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(defaultStyleSheetPath));
        styleSheets.Add(Resources.Load<StyleSheet>(styleSheetPath));

        VisualElement dialogContainer = new VisualElement();
        dialogContainer.AddToClassList(ussDialogContainer);

        Label label = new Label() { text = "OOPS! Steam initialization failed" };
        label.AddToClassList(ussLabel);
        dialogContainer.Add(label);


        Button retryButton = new AButton() { text = "Retry" };

        retryButton.clicked += ButtonClickedRetry;
        retryButton.AddToClassList(ussRetryButton);
        Button offlineButton = new AButton() { text = "Play Local" };
        offlineButton.clicked += ButtonClickedOffline;
        offlineButton.AddToClassList(ussOfflineButton);
        
        dialogContainer.Add(retryButton);
        dialogContainer.Add(offlineButton);
        
        Add(dialogContainer);
    }

    public event Action ClickedRetry;
    public event Action ClickedOffline;
    private void ButtonClickedRetry()
    {
    }

    private void ButtonClickedOffline()
    {

    }
}