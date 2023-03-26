using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class DialogueTreeSuperclass : MonoBehaviour
{
    protected bool inputGiven = false;
    protected bool isTalking = false;

    protected enum dialogueStep { showMessage, showOptions, endMessage }
    protected dialogueStep currentStep = dialogueStep.showMessage;

    [SerializeField] protected TextMeshProUGUI textObject;
    protected SpriteRenderer spriteRenderer;

    public IEnumerator BeginDialogue()
    {
        while (true)
        {
            if (inputGiven)
            {
                switch (currentStep)
                {
                    case dialogueStep.showMessage:
                        DisplayMessage();
                        currentStep = dialogueStep.showOptions;
                        inputGiven = false;
                        break;

                    case dialogueStep.showOptions:
                        DisplayOptions();
                        currentStep = dialogueStep.endMessage;
                        inputGiven = false;
                        break;

                    case dialogueStep.endMessage:
                        if (IsDoneTalking())
                        {
                            DisplayPartingMessage();
                            yield return new WaitForSeconds(3f);
                            EndDialogue();
                        }
                        currentStep = dialogueStep.showMessage;
                        break;
                }
            }

            yield return null;
        }
    }

    protected abstract void DisplayMessage();

    protected abstract void DisplayOptions();

    protected abstract void DisplayPartingMessage();

    protected virtual bool IsDoneTalking()
    {
        return true;
    }

    protected virtual void EndDialogue()
    {
        StopAllCoroutines();

        Color temp = spriteRenderer.color;
        temp.a = 0.6f;
        spriteRenderer.color = temp;

        inputGiven = false;
        isTalking = false;

        textObject.text = "";

        currentStep = dialogueStep.showMessage;
    }

    protected void OnMouseDown()
    {
        if (!isTalking)
        {
            Color temp = spriteRenderer.color;
            temp.a = 1f;
            spriteRenderer.color = temp;

            isTalking = true;
            inputGiven = true;

            currentStep = dialogueStep.showMessage;

            StartCoroutine(BeginDialogue());
        }
    }

    public void GiveContinueInput()
    {
        inputGiven = true;
    }

    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
