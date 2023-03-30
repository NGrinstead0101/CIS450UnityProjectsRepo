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

    public void Steer(int direction)
    {
        // handle driving at boost speed
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
