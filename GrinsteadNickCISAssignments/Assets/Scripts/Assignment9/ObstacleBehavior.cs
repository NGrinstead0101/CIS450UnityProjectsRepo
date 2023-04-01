using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    [SerializeField] Vector2 moveForce;
    [SerializeField] Vector2 fasterMoveForce;
    [SerializeField] Vector2 boostMoveForce;
    Rigidbody2D rb2d;

    CarContext carContext;

    private void Awake()
    {
        carContext = GameObject.FindGameObjectWithTag("Player").GetComponent<CarContext>();

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = moveForce;
    }

    private void Update()
    {
        if (carContext.currentState == CarContext.stoppedState)
        {
            rb2d.velocity = Vector2.zero;
        }
        else if (carContext.currentState == CarContext.speed1State)
        {
            rb2d.velocity = moveForce;
        }
        else if (carContext.currentState == CarContext.speed2State)
        {
            rb2d.velocity = fasterMoveForce;
        }
        else
        {
            rb2d.velocity = boostMoveForce;
        }

        if (transform.position.x <= -11 && gameObject != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
