/*
 * Nick Grinstead
 * InputReader.cs
 * Assigment 1 - OOP Review
 * This class reads user inputs in order to test the methods of the two 
 * concrete classes, Merchant and Townsfolk.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] GameObject merchantNPC;
    [SerializeField] GameObject townsfolkNPC;

    private ICanMove[] movingNPCs;

    /// <summary>
    /// Initializes array of all NPCs that can move on Awake
    /// </summary>
    private void Awake()
    {
        movingNPCs = new ICanMove[] { merchantNPC.GetComponent<ICanMove>(),
            townsfolkNPC.GetComponent<ICanMove>() };
    }

    /// <summary>
    /// Checks for inputs each frame and calls the corresponding functions
    /// The 1 key makes the townsfolk talk
    /// The 2 key makes the merchant talk
    /// The 3 key has the merchant sell an item
    /// The 4 key makes both NPCs move
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            townsfolkNPC.GetComponent<NPC>().Talk();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            merchantNPC.GetComponent<NPC>().Talk();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            merchantNPC.GetComponent<ISellsItems>().SellItem();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            foreach (ICanMove moveableNPC in movingNPCs)
            {
                moveableNPC.Move();
            }
        }
    }
}
