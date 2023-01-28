using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhombus : MoveableObject
{
    [SerializeField] float minSize;

    public override void ChangeSize()
    {
        if (!(transform.localScale.x <= minSize) || !(transform.localScale.y <= minSize))
        {
            transform.localScale -= new Vector3(moveSpeed, moveSpeed, 0) * Time.deltaTime;
        }
    }
}
