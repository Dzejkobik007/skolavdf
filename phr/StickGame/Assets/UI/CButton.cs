using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AButton : Button
{
    public AButton() { 
        base.clicked += PlayClickSound;
    }

    private void PlayClickSound() { 
        Resources.Load<AudioClip>("buttonClick");
    }
}
