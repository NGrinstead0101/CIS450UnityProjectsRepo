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

    [SerializeField] List<string> statList;
    [SerializeField] List<string> gearList;

    bool hasEquippedGear = false;
    Button equipButton;

    private void Awake()
    {
        equipButton = GetComponent<Button>();

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

    public void EquipGear()
    {
        if (!hasEquippedGear)
        {
            hasEquippedGear = true;
            equipButton.interactable = false;

            for (int i = 1; i < 5; ++i)
            {
                GameObject temp = Instantiate(menuItemPrefab, gearPanel);
                temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = gearList[i];
                MenuItem tempItem = temp.GetComponent<MenuItem>();
                tempItem.Hide();
                gearButton.Add(tempItem);
            }
        }
    }
}
