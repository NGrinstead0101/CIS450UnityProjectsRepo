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

    public void Steer(int direction)
    {
        // handle driving at speed 2
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
        Debug.Log("You can't crash when boosting");
    }
}
