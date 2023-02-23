/*
 * Nick Grinstead
 * AddOnContainer.cs
 * Assignment 6
 * This class is a factory that instantiates one of three types of additional
 * topping prefabs.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddOnContainer : ToppingContainer
{
    /// <summary>
    /// Handles instantiation of additional topping prefabs
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

        if (mousePos.y - transform.position.y > 1.5f)
        {
            GrapTopping(0);
        }
        else if (Mathf.Abs(mousePos.y - transform.position.y) <= 1.5f)
        {
            GrapTopping(1);
        }
        else
        {
            GrapTopping(2);
        }
    }
}
