using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : IMoveBehavior
{
    public void Move(float speed, Transform objectTransform)
    {
        objectTransform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
    }
}
