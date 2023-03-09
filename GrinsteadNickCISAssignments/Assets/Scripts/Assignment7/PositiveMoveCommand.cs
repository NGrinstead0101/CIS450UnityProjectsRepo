using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveMoveCommand : Command
{
    public PositiveMoveCommand(Receiver receiver)
    {
        currentReceiver = receiver;
    }

    public override void Execute()
    {
        if (currentReceiver != null)
        {
            positionHistory.Push(currentReceiver.GetPosition());
            currentReceiver.Move(1);
        }
    }

    public override void EndExecute()
    {
        if (currentReceiver != null)
        {
            currentReceiver.StopMovement();
        }
    }

    public override void Undo()
    {
        if (positionHistory.Count > 0)
        {
            Vector2 tempPos = positionHistory.Pop();
            currentReceiver.SetPosition(tempPos);
        }
    }
}
