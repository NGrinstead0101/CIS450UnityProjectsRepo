/*
 * Nick Grinstead
 * Merchant.cs
 * Assigment 1 - OOP Review
 * This class represents a merchant NPC who can sell items, talk, and move.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : NPC, ICanMove, ISellsItems
{
    [SerializeField] int goldTotal;

    /// <summary>
    /// Highlights the NPC and displays their dialogue text
    /// </summary>
    public override void Talk()
    {
        // Highlights NPC
        Color tempColor = GetComponent<SpriteRenderer>().color;
        tempColor.a = 1f;
        GetComponent<SpriteRenderer>().color = tempColor;

        dialogueBox.text = "Hello, I'm a merchant who can sell you an item!";

        StartCoroutine(ResetText());
    }

    /// <summary>
    /// Causes this NPC to move in a random direction
    /// </summary>
    public void Move()
    {
        Vector3 newPos = transform.position;

        newPos.x += Random.Range(-2f, 2f);
        newPos.y += Random.Range(-2f, 2f);

        transform.position = newPos;
    }

    /// <summary>
    /// Modifies the merchant's goldTotal and displays dialogue that reveals 
    /// this new total
    /// </summary>
    public void SellItem()
    {
        // Highlights NPC
        Color tempColor = GetComponent<SpriteRenderer>().color;
        tempColor.a = 1f;
        GetComponent<SpriteRenderer>().color = tempColor;

        goldTotal += Random.Range(1, 11);

        dialogueBox.text = "I sold an item and now I have " + goldTotal + " gold.";

        StartCoroutine(ResetText());
    }
}
