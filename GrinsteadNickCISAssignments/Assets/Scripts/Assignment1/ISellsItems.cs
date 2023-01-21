/*
 * Nick Grinstead
 * ISellsItems.cs
 * Assigment 1 - OOP Review
 * This is an interface to be implemented by NPCs that can sell items.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISellsItems
{
    /// <summary>
    /// When implemented, will allow an NPC to announce that they've sold an
    /// item and receive gold
    /// </summary>
    public void SellItem();
}
