/*
* Nick Grinstead
* PanelUpdater.cs
* Assignment 12
* This class adds MenuItems to the correct MenuButton and puts their objects 
* into panels in the UI.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelUpdater : MonoBehaviour
{
    [SerializeField] GameObject menuItemPrefab;
    [SerializeField] Transform statsPanel;
    [SerializeField] Transform gearPanel;

    [SerializeField] MenuButton statsButton;
    [SerializeField] MenuButton gearButton;

    [SerializeField] ButtonHandler gearButtonHandler;

    [SerializeField] List<string> statList;
    [SerializeField] List<string> gearList;

    bool hasEquippedGear = false;

    /// <summary>
    /// Creates initial MenuItems
    /// </summary>
    private void Awake()
    { 
        for (int i = 0; i < 5; ++i)
        {
            GameObject temp = Instantiate(menuItemPrefab, statsPanel);
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = statList[i];
            MenuItem tempItem = temp.GetComponent<MenuItem>();
            tempItem.Hide();
            statsButton.Add(tempItem);
        }

        GameObject tempGear = Instantiate(menuItemPrefab, gearPanel);
        tempGear.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = gearList[0];
        MenuItem tempGearItem = tempGear.GetComponent<MenuItem>();
        tempGearItem.Hide();
        gearButton.Add(tempGearItem);
    }

    /// <summary>
    /// Called by a button to add new MenuItems as leaves to gearButton
    /// </summary>
    public void EquipGear()
    {
        if (!hasEquippedGear)
        {
            hasEquippedGear = true;

            for (int i = 1; i < 5; ++i)
            {
                GameObject temp = Instantiate(menuItemPrefab, gearPanel);
                temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = gearList[i];
                MenuItem tempItem = temp.GetComponent<MenuItem>();
                
                if (!gearButtonHandler.isActive)
                {
                    tempItem.Hide();
                }

                gearButton.Add(tempItem);
            }

            gameObject.SetActive(false);
        }
    }
}
