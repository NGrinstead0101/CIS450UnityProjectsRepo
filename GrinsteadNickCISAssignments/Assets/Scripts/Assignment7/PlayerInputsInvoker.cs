/*
 * Nick Grinstead
 * PlayerInputsInvoker.cs
 * Assignment 7
 * This class invokes commands when the player gives certain inputs.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputsInvoker : MonoBehaviour
{
    Stack<Command> commandHistory = new Stack<Command>();
    PositiveMoveCommand posMove;
    NegativeMoveCommand negMove;

    /// <summary>
    /// To be called by a CommandSetter to update this scripts commands
    /// </summary>
    /// <param name="newReceiver"></param>
    public void SetCommands(Receiver newReceiver)
    {
        posMove = new PositiveMoveCommand(newReceiver);
        negMove = new NegativeMoveCommand(newReceiver);
    }

    /// <summary>
    /// Reads player input and invokes the appropriate commands
    /// </summary>
    private void Update()
    {
        // Execute a positive move command
        if (Input.GetMouseButton(0) && posMove != null)
        {
            commandHistory.Push(posMove);
            posMove.Execute();
        }

        // Stop a positive move command
        if (Input.GetMouseButtonUp(0) && posMove != null)
        {
            posMove.EndExecute();
        }

        // Execute a negative move command
        if (Input.GetMouseButton(1) && negMove != null)
        {
            commandHistory.Push(negMove);
            negMove.Execute();
        }

        // Stop a negative move command
        if (Input.GetMouseButtonUp(1) && negMove != null)
        {
            negMove.EndExecute();
        }

        // Undo commands
        if (Input.GetKey(KeyCode.LeftShift) && commandHistory.Count != 0)
        {
            Command tempCommand = commandHistory.Pop();
            tempCommand.Undo();
        }
    }
}
