using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    bool isActive = false;
    Image buttonImage;
    Color defaultColor;
    [SerializeField] MenuComponent buttonComponent;
    [SerializeField] List<ButtonHandler> buttonHandlers;

    private void Awake()
    {
        buttonImage = GetComponent<Image>();
        defaultColor = buttonImage.color;
    }

    public void ButtonClicked()
    {
        SetIsActive(!isActive);
    }

    public void SetIsActive(bool active)
    {
        isActive = active;

        if (isActive)
        {
            buttonImage.color = Color.yellow;

            if (buttonComponent != null)
            {
                buttonComponent.Reveal();
            }
            else
            {
                foreach (ButtonHandler button in buttonHandlers)
                {
                    button.SetIsActive(isActive);
                }
            }
        }
        else
        {
            buttonImage.color = defaultColor;

            if (buttonComponent != null)
            {
                buttonComponent.Hide();
            }
            else
            {
                foreach (ButtonHandler button in buttonHandlers)
                {
                    button.SetIsActive(isActive);
                }
            }
        }
    }
}
