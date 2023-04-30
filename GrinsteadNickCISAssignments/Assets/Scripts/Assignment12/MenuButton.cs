using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MenuComponent
{
    List<MenuComponent> menuItems = new List<MenuComponent>();
    //[SerializeField] Image buttonImage;

    public override void Reveal()
    {
        //button.enabled = true;

        foreach (MenuComponent component in menuItems)
        {
            component.Reveal();
        }
    }

    public override void Hide()
    {
        //button.enabled = false;

        foreach (MenuComponent component in menuItems)
        {
            component.Hide();
        }
    }

    public override void Add(MenuComponent component)
    {
        menuItems.Add(component);
    }

    public override void Remove(MenuComponent component)
    {
        menuItems.Remove(component);
    }

    public override MenuComponent GetChild(int index)
    {
        return menuItems[index];
    }
}
