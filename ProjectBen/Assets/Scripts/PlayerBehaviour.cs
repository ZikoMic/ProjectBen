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
<<<<<<< Updated upstream
    private float distance;
    
    public bool onLadder;
    private float defaultGravity;
=======
    public static bool alreadySet = false;
>>>>>>> Stashed changes

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentPlayer"))
        {
            PlayerPrefs.SetString("CurrentPlayer", "Male");

        }
        Debug.Log("S");
        rb = GetComponent<Rigidbody2D>();
<<<<<<< Updated upstream
        defaultGravity = rb.gravityScale;
=======
        if(alreadySet)
            alreadySet = false;
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        if (onLadder && Input.GetKey(KeyCode.W))
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, climbSpeed);
        }
        
        if (!onLadder)
        {
            rb.gravityScale = defaultGravity;
        }
=======

        if (Input.GetKeyUp(KeyCode.P)){
            if (PlayerPrefs.GetString("CurrentPlayer") == "Male")
            {
                PlayerPrefs.SetString("CurrentPlayer", "Female");
            }
        }else if (Input.GetKeyUp(KeyCode.O)){
            if (PlayerPrefs.GetString("CurrentPlayer") == "Female")
            {
                PlayerPrefs.SetString("CurrentPlayer", "Male");

            }
        }

            CameraFollow script = FindObjectOfType<Camera>().GetComponent<CameraFollow>();
            script.updateScreen();
            alreadySet = true;

>>>>>>> Stashed changes
        
        if (dead)
        {
            Destroy(GameObject.FindWithTag("Player"));
        }
    }
}