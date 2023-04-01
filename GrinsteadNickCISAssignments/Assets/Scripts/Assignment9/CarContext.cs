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

    [SerializeField] float maxDisplacement;

    bool canBoost = true;

    private void Awake()
    {
        stoppedState = new Stopped(this);
        speed1State = new Speed1(this);
        speed2State = new Speed2(this);
        boostState = new Boosting(this);

        currentState = speed1State;

        StartCoroutine(WaitTime());
    }

    // Update is called once per frame
    void Update()
    {
        float newYPos = transform.position.y;
        
        if (Input.GetAxis("Vertical") != 0)
        {
            newYPos += Steer((int) Input.GetAxis("Vertical")) * Time.deltaTime;
            newYPos = Mathf.Clamp(newYPos, -maxDisplacement, maxDisplacement);
            transform.position = new Vector2(transform.position.x, newYPos);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canBoost)
        {
            canBoost = false;
            StartCoroutine(BoostCooldown());
            Boost();
        }
    }

    private float Steer(int direction)
    {
        return currentState.Steer(direction);
    }

    private void Boost()
    {
        currentState.Boost();
    }

    private IEnumerator WaitTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            currentState.OnWait();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.OnCollision();
    }

    private IEnumerator BoostCooldown()
    {
        yield return new WaitForSeconds(3f);

        canBoost = true;

        StopCoroutine(BoostCooldown());
    }
}
