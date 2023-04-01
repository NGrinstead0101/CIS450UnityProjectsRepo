using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed2 : State
{
    CarContext context;

    public Speed2(CarContext context)
    {
        this.context = context;
    }

    public float Steer(int direction)
    {
        // handle driving at speed 2
        return direction * 10;
    }

    public void Boost()
    {
        Debug.Log("State is boost");
        context.currentState = CarContext.boostState;
    }

    public void OnWait()
    {
        Debug.Log("You're already at max speed");
    }

    public void OnCollision()
    {
        Debug.Log("State is stopped");
        context.currentState = CarContext.stoppedState;
    }
}
