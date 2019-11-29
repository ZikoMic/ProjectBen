using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonControllerScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI title;
    public TMPro.TextMeshProUGUI description;


    public void SetCurrent(string n)
    {
        title.text = GetTitle(n);
        description.text = GetTitle(n);
        Debug.Log("Set");
    }

    string GetTitle(string n)
    {
        switch (n)
        {
            case "level1":
                return "Damage Resistance";

            default:
                return "Testing Value";
        }
    }

    string GetDescription(string n)
    {
        switch (n)
        {
            case "level1":
                return "This item increases the amount of damage the player can withstand before dying";

            default:
                return "Lorem ipsum bla bla bla bla bal bla bla bla bla bal bla bla bla bla bal";
        }
    }
}
