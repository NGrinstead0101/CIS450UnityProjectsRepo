using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputsInvoker : MonoBehaviour
{
    Stack<Command> commandHistory = new Stack<Command>();
    PositiveMoveCommand posMove;
    NegativeMoveCommand negMove;

    public void SetCommands(Receiver newReceiver)
    {
        Debug.Log("Setting commands");
        posMove = new PositiveMoveCommand(newReceiver);
        negMove = new NegativeMoveCommand(newReceiver);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && posMove != null)
        {
            Debug.Log("Positive move called");
            commandHistory.Push(posMove);
            posMove.Execute();
        }

        if (Input.GetMouseButtonUp(0) && posMove != null)
        {
            posMove.EndExecute();
        }

        if (Input.GetMouseButton(1) && negMove != null)
        {
            Debug.Log("Negative move called");
            commandHistory.Push(negMove);
            negMove.Execute();
        }

        if (Input.GetMouseButtonUp(1) && negMove != null)
        {
            negMove.EndExecute();
        }

        if (Input.GetKey(KeyCode.LeftShift) && commandHistory.Count != 0)
        {
            Command tempCommand = commandHistory.Pop();
            tempCommand.Undo();
        }
    }
}
