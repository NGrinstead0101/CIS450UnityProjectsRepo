/*
 * Nick Grinstead
 * Command.cs
 * Assignment 7
 * This abstract class represents a command object that can tell a receiver to
 * take a certain action.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected Stack<Vector2> positionHistory = new Stack<Vector2>();
    protected Receiver currentReceiver;

    /// <summary>
    /// Executes the command
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// Stops the command when a key is released
    /// </summary>
    public abstract void EndExecute();

    /// <summary>
    /// Undoes the most recent command
    /// </summary>
    public abstract void Undo();
}
