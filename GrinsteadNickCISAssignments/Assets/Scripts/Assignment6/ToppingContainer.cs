/*
 * Nick Grinstead
 * ToppingContainer.cs
 * Assignment 6
 * This class represents an abstract factory that creates topping objects.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ToppingContainer : MonoBehaviour
{
    [SerializeField] protected GameObject[] toppingPrefabs = new GameObject[3];

    /// <summary>
    /// Handles instantiation of topping prefabs
    /// </summary>
    /// <param name="typeIndex">Index of prefab in toppingPrefabs</param>
    public abstract void GrapTopping(int typeIndex);
}
