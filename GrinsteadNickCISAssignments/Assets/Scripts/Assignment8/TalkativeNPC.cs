using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkativeNPC : DialogueTreeSuperclass
{
    [SerializeField] string[] messageArray;
    private int messageIndex = 0;
    [SerializeField] GameObject[] optionButtons;
    bool optionSelection;

    protected override void DisplayMessage()
    {
        foreach (GameObject button in optionButtons)
        {
            button.SetActive(false);
        }    

        textObject.text = messageArray[messageIndex];

        messageIndex++;
        messageIndex %= messageArray.Length;

        Invoke("GiveContinueInput", 2f);
    }

    protected override void DisplayOptions()
    {
        for (int i = 0; i < optionButtons.Length; ++i)
        {
            optionButtons[i].SetActive(true);
        }
    }

    protected override void DisplayPartingMessage()
    {
        foreach (GameObject button in optionButtons)
        {
            button.SetActive(false);
        }

        textObject.text = "\"Oh, it seems that I've finally run out of dialogue! Farewell!\"";
    }

    protected override bool IsDoneTalking()
    {
        if (optionSelection)
        {
            messageIndex = 0;
        }

        return optionSelection;
    }

    public void ButtonClicked(bool option)
    {
        optionSelection = option;
    }
}
