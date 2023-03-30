using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopped : State
{
    CarContext context;

    public Stopped(CarContext context)
    {
        this.context = context;
    }

    public void Steer(int direction)
    {
        Debug.Log("You can't drive when stopped");
    }

    public void Boost()
    {
        Debug.Log("You can't boost when stopped");
    }

    public void OnWait()
    {
        context.currentState = CarContext.speed1State;
    }

    public void OnCollision()
    {
        Debug.Log("You've already collided with something");
    }
}
