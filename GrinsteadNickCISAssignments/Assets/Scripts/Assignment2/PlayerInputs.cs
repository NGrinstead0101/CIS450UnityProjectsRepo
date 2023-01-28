/*
 * Nick Grinstead
 * PlayerInputs.cs
 * Assignment 2
 * This class handles the effects of player inputs and moves the player character.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D rb2d;

    IMoveBehavior[] moveBehaviors = new IMoveBehavior[] { new MoveRight(), new MoveLeft(), new Rotate() };
    GameObject[] moveableObjects;

    bool canJump = true;

    /// <summary>
    /// Initializing moveableObjects array and setting initial move behaviors
    /// </summary>
    private void Awake()
    {
        moveableObjects = GameObject.FindGameObjectsWithTag("MovingObject");

        RandomizeMoveBehavoirs();
    }

    /// <summary>
    /// Checks for input every frame and takes corresponding action
    /// </summary>
    private void Update()
    {
        // Walk input
        if (Input.GetKey(KeyCode.A))
        {
            Walk(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Walk(1);
        }

        // Jump input
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        // Reset objects
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        // Randomize movement behavoirs
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RandomizeMoveBehavoirs();
        }

        // Move all objects
        if (Input.GetKey(KeyCode.Mouse0))
        {
            foreach (GameObject movingObject in moveableObjects)
            {
                MoveableObject moveableScript = movingObject.GetComponent<MoveableObject>();

                if (moveableScript != null)
                {
                    moveableScript.DoMove();
                }
            }
        }

        // Resize all objects
        if (Input.GetKey(KeyCode.Mouse1))
        {
            foreach (GameObject movingObject in moveableObjects)
            {
                MoveableObject moveableScript = movingObject.GetComponent<MoveableObject>();

                if (moveableScript != null)
                {
                    moveableScript.ChangeSize();
                }
            }
        }
    }

    /// <summary>
    /// Randomizes movement behavior for all objects in moveableObjects array
    /// </summary>
    private void RandomizeMoveBehavoirs()
    {
        foreach (GameObject movingObject in moveableObjects)
        {
            MoveableObject moveableScript = movingObject.GetComponent<MoveableObject>();

            if (moveableScript != null)
            {
                moveableScript.SetMoveBehavoir(moveBehaviors[Random.Range(0, 3)]);
            }
        }
    }

    /// <summary>
    /// Moves player character horizontally
    /// </summary>
    /// <param name="direction">Will be 1 or -1 to determine movement direction</param>
    private void Walk(int direction)
    {
        Vector2 newPos = transform.position;

        newPos.x += direction * moveSpeed * Time.deltaTime;

        transform.position = newPos;
    }

    /// <summary>
    /// Adds vertical force to the player
    /// </summary>
    private void Jump()
    {
        canJump = false;
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    /// <summary>
    /// Ensures the player can't jump once they're in the air
    /// </summary>
    /// <param name="collision">Data from a collision</param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        canJump = false;
    }

    /// <summary>
    /// Ensures player can jump when standing on the ground
    /// </summary>
    /// <param name="collision">Data from a collision</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Wall"))
        {
            canJump = true;
        }
    }
}
