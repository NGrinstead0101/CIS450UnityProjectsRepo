using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ReservedNPC : DialogueTreeSuperclass
{
    [SerializeField] string message;
    [SerializeField] GameObject optionButton;

    protected override void DisplayMessage()
    {
        optionButton.SetActive(false);

        textObject.text = message;

        Invoke("GiveContinueInput", 2f);
    }

    protected override void DisplayOptions()
    {
        optionButton.SetActive(true);
    }

    protected override void DisplayPartingMessage()
    {
        optionButton.SetActive(false);

        textObject.text = "\"Our conversation may have been short, but it was nice talking to you!\"";
    }
}
