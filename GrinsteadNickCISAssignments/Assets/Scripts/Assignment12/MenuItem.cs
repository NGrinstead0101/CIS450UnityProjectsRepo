using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuItem : MenuComponent
{
    [SerializeField] Image itemObject;
    [SerializeField] TextMeshProUGUI itemText;

    public override void Reveal()
    {
        itemObject.enabled = true;
        itemText.enabled = true;
    }

    public override void Hide()
    {
        itemObject.enabled = false;
        itemText.enabled = false;
    }
}
