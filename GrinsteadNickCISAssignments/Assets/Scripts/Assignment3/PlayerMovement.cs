/*
 * Nick Grinstead
 * PlayerMovement.cs
 * Assignment 3
 * Reads input in order to allow the player to move around both horizontally
 * and vertically.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    /// <summary>
    /// Uses WASD inputs to allow player to move
    /// </summary>
    void Update()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
