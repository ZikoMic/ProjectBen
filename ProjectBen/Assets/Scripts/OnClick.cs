using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    private Sprite on, off; 
    private SpriteRenderer rend;

    void Start()
    {
        off = Resources.Load<Sprite>("Diamond");
        on = Resources.Load<Sprite>("Circle");
        rend = GetComponent<SpriteRenderer>();
        rend.sprite = off;

        if (PlayerPrefs.GetInt("level 1") == 1)
        {
            rend.sprite = off;
        }
        else
        {
            rend.sprite = on;
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rend.sprite == on)
            {
                rend.sprite = off;
            }
            else if (rend.sprite == off)
            {
                rend.sprite = on;
            }
        }
    }

    void Update()
    {

       
    }
}
