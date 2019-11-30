using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PurchaseButton : MonoBehaviour
{
    public TMPro.TextMeshProUGUI description;
    public GameObject taQabel;
    public int coins;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Damage ResistanceCost", 1);
        PlayerPrefs.SetInt("Increase SpeedCost", 1);
        PlayerPrefs.SetInt("Increase HealthCost", 3);
        PlayerPrefs.SetInt("Random3Cost", 1);
        PlayerPrefs.SetInt("ShrinkingCost", 2);
        PlayerPrefs.SetInt("InvincibleCost", 2);
        PlayerPrefs.SetInt("RandomOhraCost", 2);
        PlayerPrefs.SetInt("Random2Cost", 2);
        PlayerPrefs.SetInt("TokenCount", 2);

        PlayerPrefs.SetInt("Damage Resistance", 0);
        PlayerPrefs.SetInt("Increase Speed", 0);
        PlayerPrefs.SetInt("Increase Health", 0);
        PlayerPrefs.SetInt("Random3", 0);
        PlayerPrefs.SetInt("Shrinking", 1);
        PlayerPrefs.SetInt("Invincible", 1);
        PlayerPrefs.SetInt("Random2", 1);
        PlayerPrefs.SetInt("RandomOhra", 1);
    }


    public void OnPurchase()
    {
        string k = PlayerPrefs.GetString("ToPurchase");
        GameObject item = GameObject.Find("SkillTree/Skill Panel/" + k);
        item.GetComponent<Button>().interactable = false;




        PlayerPrefs.SetInt("TokenCount", PlayerPrefs.GetInt("TokenCount") - PlayerPrefs.GetInt(PlayerPrefs.GetString("ToPurchase") + "Cost"));

        /*
        PlayerPrefs.SetInt("Damage ResistanceCost", 1);
        PlayerPrefs.SetInt("Increase SpeedCost", 1);
        PlayerPrefs.SetInt("Increase HealthCost", 3);
        PlayerPrefs.SetInt("Random3Cost", 1);
        PlayerPrefs.SetInt("ShrinkingCost", 2);
        PlayerPrefs.SetInt("InvincibleCost", 2);
        PlayerPrefs.SetInt("RandomOhraCost", 2);
        */

        if(k == "Damage Resistance")
        {
            PlayerPrefs.SetInt("Shrinking", 0);
        }

        if (k == "Increase Health")
        {
            PlayerPrefs.SetInt("Random2", 0);
        }

        if (k == "Increase Speed")
        {
            PlayerPrefs.SetInt("Invincible", 0);
        }

        if (k == "Random3")
        {
            PlayerPrefs.SetInt("RandomOhra", 0);
        }
        /*
        PlayerPrefs.SetInt("Invincible", 1);
        PlayerPrefs.SetInt("Random2", 1);
        PlayerPrefs.SetInt("RandomOhra", 1);
        */

        PlayerPrefs.SetInt(k, 2);

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
