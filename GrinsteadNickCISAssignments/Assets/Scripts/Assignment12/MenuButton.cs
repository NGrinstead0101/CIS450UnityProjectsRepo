/*
* Nick Grinstead
* MenuButton.cs
* Assignment 12
* This class acts as a node for a menu composite. This should be attached to a 
* button that will reveal more components.
* Pattern.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MenuComponent
{
    [SerializeField] List<MenuComponent> menuItems = new List<MenuComponent>();

    Image buttonImage;
    Color defaultColor;

    /// <summary>
    /// Setting variables
    /// </summary>
    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        defaultColor = buttonImage.color;
    }

    /// <summary>
    /// Changes button color and reveals child objects
    /// </summary>
    public override void Reveal()
    {
        buttonImage.color = Color.yellow;

        foreach (MenuComponent component in menuItems)
        {
            component.Reveal();
        }
    }

    /// <summary>
    /// Reverts button color and hides child objects
    /// </summary>
    public override void Hide()
    {
        buttonImage.color = defaultColor;

        foreach (MenuComponent component in menuItems)
        {
            component.Hide();
        }
    }

    /// <summary>
    /// Adds a component to menuItems
    /// </summary>
    /// <param name="component">The component being added</param>
    public override void Add(MenuComponent component)
    {
        menuItems.Add(component);
    }

    /// <summary>
    /// Removes a component from menuItems
    /// </summary>
    /// <param name="component">The component being removed</param>
    public override void Remove(MenuComponent component)
    {
        menuItems.Remove(component);
    }

    /// <summary>
    /// Accesses an object in menuItems at a certain index
    /// </summary>
    /// <param name="index">The index being accessed</param>
    /// <returns>A MenuComponent</returns>
    public override MenuComponent GetChild(int index)
    {
        return menuItems[index];
    }
}
