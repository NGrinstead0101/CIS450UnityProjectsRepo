/*
 * Nick Grinstead
 * PositiveMoveCommand.cs
 * Assignment 7
 * This concrete command tells receivers to move in a positive direction, either 
 * right or up.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveMoveCommand : Command
{
    /// <summary>
    /// Constructor for this class
    /// </summary>
    /// <param name="receiver">A concrete receiver</param>
    public PositiveMoveCommand(Receiver receiver)
    {
        currentReceiver = receiver;
    }

    /// <summary>
    /// Tells receiver to move right or up
    /// </summary>
    public override void Execute()
    {
        if (currentReceiver != null)
        {
            positionHistory.Push(currentReceiver.GetPosition());
            currentReceiver.Move(1);
        }
    }

    /// <summary>
    /// Stops the receiver's movement
    /// </summary>
    public override void EndExecute()
    {
        if (currentReceiver != null)
        {
            currentReceiver.StopMovement();
        }
    }

    /// <summary>
    /// Sets the receiver's position to its last position
    /// </summary>
    public override void Undo()
    {
        if (positionHistory.Count > 0)
        {
            Vector2 tempPos = positionHistory.Pop();
            currentReceiver.SetPosition(tempPos);

            currentReceiver.StopMovement();
        }
    }
}
