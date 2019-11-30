using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControllerScript : MonoBehaviour
{
    public TMPro.TextMeshProUGUI title;
    public TMPro.TextMeshProUGUI description;
    public TMPro.TextMeshProUGUI tokenCount;
    public int coins;
    public void Start()
    {
        Redraw();

    }

    public void Redraw()
    {
        GameObject panel = GameObject.Find("SkillTree/Skill Panel");
        foreach (Transform button in panel.transform)
        {
            if (PlayerPrefs.GetInt(button.name) == 1 || PlayerPrefs.GetInt(button.name) == 2)
            {
                button.GetComponent<Button>().interactable = false;
            }
            else if (PlayerPrefs.GetInt(button.name) == 0)
            {
                button.GetComponent<Button>().interactable = true;

            }
        }
    }

    public void GoToScene()
    {
        SceneManager.LoadScene("Level1");
    }

    private void FixedUpdate()
    {
        tokenCount.text = "Tokens: " + PlayerPrefs.GetInt("TokenCount");
    }

    public void SetCurrent(string n)
    {
        title.text = GetTitle(n);
        description.text = GetDescription(n);
    }

    void AttemptPurchase(string n)
    {

        if (PlayerPrefs.GetInt(n) == 1 || PlayerPrefs.GetInt(n) == 2)
        {
            GameObject panel = GameObject.Find("SkillTree/Panel/Purchase");
            panel.GetComponent<Button>().interactable = false;

        }
        else
        {
            int getCost = PlayerPrefs.GetInt(n + "Cost");
            if (getCost > PlayerPrefs.GetInt("TokenCount"))
            {
                GameObject panel = GameObject.Find("SkillDescription/Panel/Purchase");
                panel.GetComponent<Button>().interactable = false;
            }
            else
            {
                GameObject panel = GameObject.Find("SkillDescription/Panel/Purchase");
                panel.GetComponent<Button>().interactable = true;
                PlayerPrefs.SetString("ToPurchase", n);

            }
        }
    }

    string GetTitle(string n)
    {
        switch (n)
        {
            case "Damage Resistance":
                AttemptPurchase(n);
                return "Damage Resistance";

            case "Increase Health":
                AttemptPurchase(n);
                return "Increase Health";

            case "Increase Speed":
                AttemptPurchase(n);

                return "Increase Speed";

            case "Random3":
                AttemptPurchase(n);

                return "Random3";


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

            case "level2":
                return "This increases both character's walk speed by a factor of 10%";

            case "level3":
                return "This is a dummy value that I have to fill when I feel more energetic";

            case "level4":
                return "This is aslkjdhaslk jfhsadlkfgjhasdlkgf jhasdlkj hdslkfjsdahlkf jsadh fshd";

            case "level11":
                return "This item increases the amount of damage the player can withstand before dying";

            case "level21":
                return "This item increases the amount of damage the player can withstand before dying";

            case "level31":
                return "This item increases the amount of damage the player can withstand before dying";

            case "level41":
                return "This item increases the amount of damage the player can withstand before dying";

            default:
                return "Lorem ipsum bla bla bla bla bal bla bla bla bla bal bla bla bla bla bal";
        }
    }
}
