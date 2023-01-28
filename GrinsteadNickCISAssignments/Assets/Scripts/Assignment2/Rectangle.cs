using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : MoveableObject
{
    [SerializeField] float maxSize;

    public override void ChangeSize()
    {
        if (!(transform.localScale.x >= maxSize) || !(transform.localScale.y >= maxSize))
        {
            transform.localScale += new Vector3(moveSpeed, moveSpeed, 0) * Time.deltaTime;
        }
    }
}
