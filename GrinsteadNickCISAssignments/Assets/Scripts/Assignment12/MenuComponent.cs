using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuComponent : MonoBehaviour
{
    public abstract void Reveal();

    public abstract void Hide();

    public virtual void Add(MenuComponent component)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Remove(MenuComponent component)
    {
        throw new System.NotImplementedException();
    }

    public virtual MenuComponent GetChild(int index)
    {
        throw new System.NotImplementedException();
    }
}
