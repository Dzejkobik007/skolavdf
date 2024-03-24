using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Dialog : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<Dialog> { }

    const string defaultStyleSheetPath = "Default";
    //const string ussLabel = "Label";
    const string ussDialogContainer = "Dialog";
    //const string ussRetryButton = "RetryButton";
    //const string ussOfflineButton = "RetryButton";

    public Label label = new Label();
    public Button buttonOne = new AButton();
    public Button buttonTwo = new AButton();
    public Dialog()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(defaultStyleSheetPath));

        VisualElement dialogContainer = new VisualElement();
        dialogContainer.AddToClassList(ussDialogContainer);

        //Label label = new Label() { text = "OOPS! Steam initialization failed" };
        //label.AddToClassList(ussLabel);
        dialogContainer.Add(label);


        //Button retryButton = new AButton() { text = "Retry" };

        //retryButton.clicked += ButtonClickedRetry;
        //retryButton.AddToClassList(ussRetryButton);
        //Button offlineButton = new AButton() { text = "Play Local" };
        //offlineButton.clicked += ButtonClickedOffline;
        //offlineButton.AddToClassList(ussOfflineButton);

        //dialogContainer.Add(retryButton);
        //dialogContainer.Add(offlineButton);

        buttonOne.clicked += ButtonOneClicked;
        buttonTwo.clicked += ButtonTwoClicked;
        dialogContainer.Add(buttonOne);
        dialogContainer.Add(buttonTwo);

        Add(dialogContainer);
    }

    public event Action ButOneClicked;
    public event Action ButTwoClicked;
    private void ButtonOneClicked()
    {
        ButOneClicked?.Invoke();
    }

    private void ButtonTwoClicked()
    {
        ButTwoClicked?.Invoke();
    }
}