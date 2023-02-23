/*
 * Nick Grinstead
 * CheeseContainer.cs
 * Assignment 6
 * This class is a factory that instantiates one of two types of cheese topping
 * prefabs.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseContainer : ToppingContainer
{
    /// <summary>
    /// Handles instantiation of cheese topping prefabs
    /// </summary>
    /// <param name="typeIndex">Index of prefab in toppingPrefabs</param>
    public override void GrapTopping(int typeIndex)
    {
        if (typeIndex < toppingPrefabs.Length)
        {
            Topping newTopping = Instantiate(toppingPrefabs[typeIndex]).GetComponent<Topping>();
            newTopping.ChoosePosition();
        }
    }

    /// <summary>
    /// When clicked, calls GrapTopping with an int based on the mouse's position
    /// </summary>
    private void OnMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (mousePos.y - transform.position.y > 0f)
        {
            GrapTopping(0);
        }
        else if (mousePos.y - transform.position.y <= 0f)
        {
            GrapTopping(1);
        }
    }
}
