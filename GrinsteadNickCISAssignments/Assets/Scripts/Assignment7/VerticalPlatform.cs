using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : Receiver
{
    public override void Move(int direction)
    {
        Vector2 force = Vector2.up * direction * speed;

        //newPos.y += direction * speed * Time.deltaTime;

        //newPos.y = Mathf.Clamp(newPos.y, initialPos.y - maxDistance, initialPos.y + maxDistance);

        GetComponent<Rigidbody2D>().velocity = force;
    }
}
