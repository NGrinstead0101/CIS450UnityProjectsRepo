using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody2D rb2d;

    IMoveBehavior[] moveBehaviors = new IMoveBehavior[] { new MoveRight(), new MoveLeft(), new Rotate() };
    GameObject[] moveableObjects;

    bool canJump = true;

    private void Awake()
    {
        moveableObjects = GameObject.FindGameObjectsWithTag("MovingObject");

        RandomizeMoveBehavoirs();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Walk(-1);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Walk(1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            RandomizeMoveBehavoirs();
        }

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

    private void Walk(int direction)
    {
        Vector2 newPos = transform.position;

        newPos.x += direction * moveSpeed * Time.deltaTime;

        transform.position = newPos;
    }

    private void Jump()
    {
        canJump = false;
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
