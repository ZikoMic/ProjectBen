using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using System.Linq;

public class PlayerBehaviour : MonoBehaviour
{
    public float climbSpeed = 10f;
    private Rigidbody2D rb;
    private bool dead = false;
    private float distance;
    
    public bool onLadder;
    private float defaultGravity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravity = rb.gravityScale;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        string[] deathObjects = {"Spikes", "DeathBox"};

        if (deathObjects.Contains(collider.gameObject.tag))
        {
            dead = true;
        }
    }

    private void Update()
    {
        if (onLadder && Input.GetKey(KeyCode.W))
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
        }
        
        if (!onLadder)
        {
            rb.gravityScale = defaultGravity;
        }
        
        if (dead)
        {
            Destroy(GameObject.FindWithTag("Player"));
        }
    }
}