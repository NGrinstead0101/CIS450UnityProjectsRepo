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

    public float Steer(int direction)
    {
        Debug.Log("You can't drive when stopped");
        return 0;
    }

    public void Boost()
    {
        Debug.Log("You can't boost when stopped");
    }

    public void OnWait()
    {
        Debug.Log("State is Speed1");
        context.currentState = CarContext.speed1State;
    }

    public void OnCollision()
    {
        Debug.Log("You've already collided with something");
    }
}
