/*
 * Nick Grinstead
 * Townsfolk.cs
 * Assigment 1 - OOP Review
 * This class represents a townsfolk NPC who can talk about their home town and 
 * move about.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Townsfolk : NPC, ICanMove
{
    [SerializeField] string homeTown;

    /// <summary>
    /// Highlights the NPC and displays their dialogue text
    /// </summary>
    public override void Talk()
    {
        // Highlights NPC
        Color tempColor = GetComponent<SpriteRenderer>().color;
        tempColor.a = 1f;
        GetComponent<SpriteRenderer>().color = tempColor;

        dialogueBox.text = "Hello! I'm from " + homeTown + ".";

        StartCoroutine(ResetText());
    }

    /// <summary>
    /// Causes this NPC to move in a random direction
    /// </summary>
    public void Move()
    {
        Vector3 newPos = transform.position;

        newPos.x += Random.Range(-3f, 3f);
        newPos.y += Random.Range(-3f, 3f);

        transform.position = newPos;
    }
}
