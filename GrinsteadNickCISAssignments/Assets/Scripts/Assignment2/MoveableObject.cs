using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveableObject : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    IMoveBehavior moveBehavior;

    public void SetMoveBehavoir(IMoveBehavior newBehavoir)
    {
        moveBehavior = newBehavoir;
    }

    public void DoMove()
    {
        if (moveBehavior != null)
        {
            moveBehavior.Move(moveSpeed, transform);
        }
    }

    public abstract void ChangeSize();
}
