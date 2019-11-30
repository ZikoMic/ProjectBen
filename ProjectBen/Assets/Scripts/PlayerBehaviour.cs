using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using System.Linq; 

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool dead = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collider){
        string[] deathObjects = {"Spikes", "DeathBox"};
        
        if(deathObjects.Contains(collider.gameObject.tag) )
        {
            dead = true; 
        }
    }

    private void Update()
    {
        if (dead)
        {
            Destroy (GameObject.FindWithTag("Player")); 
        }
    }
}
