/*
* Nick Grinstead
* MenuItem.cs
* Assignment 12
* This class represents a leaf of a menu composite.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuItem : MenuComponent
{
    [SerializeField] Image itemObject;
    [SerializeField] TextMeshProUGUI itemText;

    /// <summary>
    /// Reveals this UI object
    /// </summary>
    public override void Reveal()
    {
        itemObject.enabled = true;
        itemText.enabled = true;
    }

    /// <summary>
    /// Hides this UI object
    /// </summary>
    public override void Hide()
    {
        itemObject.enabled = false;
        itemText.enabled = false;
    }
}
