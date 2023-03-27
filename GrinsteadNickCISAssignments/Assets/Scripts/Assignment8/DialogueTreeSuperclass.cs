/*
 * Nick Grinstead
 * DialogueTreeSuperclass.cs
 * Assignment 8
 * This abstract class acts as a template for the process of moving through a 
 * dialogue tree. This is meant to be attached to an NPC gameobject.
 */
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

    /// <summary>
    /// Acts as a template method that displays a message, displays options, and
    /// then checks if a parting message should be displayed
    /// </summary>
    /// <returns>An amount of time to wait</returns>
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

    /// <summary>
    /// Abstract step to reveal a message or messages
    /// </summary>
    protected abstract void DisplayMessage();

    /// <summary>
    /// Abstract step to display any dialogue/conversation options
    /// </summary>
    protected abstract void DisplayOptions();

    /// <summary>
    /// Abstract step to display a parting message
    /// </summary>
    protected abstract void DisplayPartingMessage();

    /// <summary>
    /// Hook used to check if the conversation is over
    /// </summary>
    /// <returns>A bool that's true by default</returns>
    protected virtual bool IsDoneTalking()
    {
        return true;
    }

    /// <summary>
    /// Ends the dialogue and resets the dialogue tree
    /// </summary>
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

    /// <summary>
    /// Starts a conversation when the attached NPC is clicked
    /// </summary>
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

    /// <summary>
    /// To be called elsewhere to allow the function to advance to the next step
    /// </summary>
    public void GiveContinueInput()
    {
        inputGiven = true;
    }

    /// <summary>
    /// Setting spriterenderer reference
    /// </summary>
    protected void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
