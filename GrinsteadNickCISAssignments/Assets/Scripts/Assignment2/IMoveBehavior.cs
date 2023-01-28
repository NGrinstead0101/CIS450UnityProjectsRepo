using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveBehavior
{
    public void Move(float speed, Transform objectTransform);
}
