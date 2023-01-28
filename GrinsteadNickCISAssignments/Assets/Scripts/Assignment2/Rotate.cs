using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : IMoveBehavior
{
    public void Move(float speed, Transform objectTransform)
    {
        objectTransform.eulerAngles += new Vector3(0, 0, speed) * Time.deltaTime;
    }
}
