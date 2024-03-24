using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InfoText : VisualElement
{
    [UnityEngine.Scripting.Preserve]

    public new class UxmlFactory : UxmlFactory<InfoText> { }

    const string styleSheetPath = "Default";
    const string ussInfoText = "InfoText";

    Label label = new Label() { text = "Some text to fill this thing" };

    public InfoText()
    {
        styleSheets.Add(Resources.Load<StyleSheet>(styleSheetPath));
        AddToClassList(ussInfoText);
        Add(label);
    }

    public void SetText(string text)
    {
        label.text = text;
    }
}