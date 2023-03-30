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

    public void Steer(int direction)
    {
        // handle driving at speed 1
    }

    public void Boost()
    {
        context.currentState = CarContext.boostState;
    }

    public void OnWait()
    {
        context.currentState = CarContext.speed2State;
    }

    public void OnCollision()
    {
        context.currentState = CarContext.stoppedState;
    }
}
