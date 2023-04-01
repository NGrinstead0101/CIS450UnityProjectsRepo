using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boosting : State
{
    CarContext context;

    public Boosting(CarContext context)
    {
        this.context = context;
    }

    public float Steer(int direction)
    {
        // handle driving at boost speed
        return direction * 20;
    }

    public void Boost()
    {
        Debug.Log("You're already boosting");
    }

    public void OnWait()
    {
        Debug.Log("State is Speed2");
        context.currentState = CarContext.speed2State;
    }

    public void OnCollision()
    {
        Debug.Log("You can't crash while boosting");
    }
}
