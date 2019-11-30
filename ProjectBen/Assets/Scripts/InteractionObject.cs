using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionObject : MonoBehaviour
{
    public bool locked;
    public int requiredKeys = 1;


    public void DoInteraction()
    {
        gameObject.SetActive(false);  
    }



}

