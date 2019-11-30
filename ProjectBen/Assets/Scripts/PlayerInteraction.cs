using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public InteractionObject currentInterObjScript = null;
    public int keys = 0;
    private int inElevator = 0;

    private void Update()
    {
        if (keys >= currentInterObjScript.requiredKeys)
        {
            keys = currentInterObjScript.requiredKeys;
            currentInterObjScript.locked = false;
            Destroy(GameObject.FindGameObjectWithTag("Lock"));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Elevator"))
        {
            if (currentInterObjScript.locked && (keys >= currentInterObjScript.requiredKeys))
            {
                keys = currentInterObjScript.requiredKeys;
                currentInterObjScript.locked = false;
                Debug.Log("Open Door");
            }
            else
            {
                Debug.Log("Locked Door");
            }
            
            if ((!currentInterObjScript.locked))
            {
                SceneManager.LoadScene("Level1");
            }
        }

        if (other.CompareTag("Key"))
        {
            keys++;
            Destroy(GameObject.FindGameObjectWithTag("Key"));
        }
    }
}