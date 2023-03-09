using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : Receiver
{
    public override void Move(int direction)
    {
        Vector2 force = Vector2.right * direction * speed;

        //newPos.x += direction * speed * Time.deltaTime;

        //newPos.x = Mathf.Clamp(newPos.y, initialPos.x - maxDistance, initialPos.x + maxDistance);

        GetComponent<Rigidbody2D>().velocity = force;

    }
}
