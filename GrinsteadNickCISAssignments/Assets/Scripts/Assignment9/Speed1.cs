using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed1 : State
{
    CarContext context;

    public Speed1(CarContext context)
    {
        this.context = context;
    }

    public float Steer(int direction)
    {
        // handle driving at speed 1
        return direction * 5;
    }

    public void Boost()
    {
        Debug.Log("State is boost");
        context.currentState = CarContext.boostState;
    }

    public void OnWait()
    {
        Debug.Log("State is Speed2");
        context.currentState = CarContext.speed2State;
    }

    public void OnCollision()
    {
        Debug.Log("State is stopped");
        context.currentState = CarContext.stoppedState;
    }
}
