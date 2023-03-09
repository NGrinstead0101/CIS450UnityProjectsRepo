using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    protected Stack<Vector2> positionHistory = new Stack<Vector2>();
    protected Receiver currentReceiver;

    public abstract void Execute();

    public abstract void EndExecute();

    public abstract void Undo();
}
