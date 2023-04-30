/*
* Nick Grinstead
* MenuComponent.cs
* Assignment 12
* This abstract class represents a menu component to be used by the Composite
* Pattern.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuComponent : MonoBehaviour
{
    /// <summary>
    /// Reveals/activates the component
    /// </summary>
    public abstract void Reveal();

    /// <summary>
    /// Hides/deactivates the component
    /// </summary>
    public abstract void Hide();

    /// <summary>
    /// To be overriden by node objects for adding components
    /// </summary>
    /// <param name="component">A component to be added</param>
    public virtual void Add(MenuComponent component)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// To be overriden by node objects for removing components
    /// </summary>
    /// <param name="component">A component to be removed</param>
    public virtual void Remove(MenuComponent component)
    {
        throw new System.NotImplementedException();
    }

    /// <summary>
    /// To be overriden by node objects for getting access to subobjects
    /// </summary>
    /// <param name="index">The index being accessed</param>
    /// <returns>Nothing, as this method is unimplemented</returns>
    public virtual MenuComponent GetChild(int index)
    {
        throw new System.NotImplementedException();
    }
}
