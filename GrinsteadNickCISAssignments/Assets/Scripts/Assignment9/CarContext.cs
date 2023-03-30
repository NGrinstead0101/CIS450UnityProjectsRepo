using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContext : MonoBehaviour
{
    public static State stoppedState;
    public static State speed1State;
    public static State speed2State;
    public static State boostState;

    public State currentState;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Steer(int direction)
    {
        currentState.Steer(direction);
    }

    private void Boost()
    {
        currentState.Boost();
    }

    private IEnumerator WaitTime()
    {
        currentState.OnWait();

        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollision();
    }
}
