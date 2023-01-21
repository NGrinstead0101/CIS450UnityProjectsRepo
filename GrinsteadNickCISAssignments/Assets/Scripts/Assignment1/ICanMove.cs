/*
 * Nick Grinstead
 * ICanMove.cs
 * Assigment 1 - OOP Review
 * This is an interface to be implemented by NPCs that can move.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanMove
{ 
    /// <summary>
    /// When implemented, will allow an NPC to change its position
    /// </summary>
    public void Move();
}
