using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    Rigidbody2D rb2d;

    bool canJump = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Walk(-1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Walk(1);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Walk(0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
    }

    private void Walk(int direction)
    {
        float moveVelocity = direction * moveSpeed;

        rb2d.velocity = new Vector2(moveVelocity, rb2d.velocity.y);
    }

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
