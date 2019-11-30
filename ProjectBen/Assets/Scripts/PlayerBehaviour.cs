using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    public float climbSpeed = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool dead = false;
    private float distance;
    private float defaultGravity;
    public static bool alreadySet = false;
    public bool onLadder;
    public bool isInvincible = false;


    private void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentPlayer"))
        {
            PlayerPrefs.SetString("CurrentPlayer", "Male");
        }

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultGravity = rb.gravityScale;
        if (alreadySet)
            alreadySet = false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isInvincible)
        {
            string[] deathObjects = {"Spikes", "DeathBox"};

            if (deathObjects.Contains(collider.gameObject.tag))
            {
                dead = true;
            }
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

        if (Input.GetKeyUp(KeyCode.P))
        {
            if (PlayerPrefs.GetString("CurrentPlayer") == "Male")
            {
                PlayerPrefs.SetString("CurrentPlayer", "Female");
            }
        }
        else if (Input.GetKeyUp(KeyCode.O))
        {
            if (PlayerPrefs.GetString("CurrentPlayer") == "Female")
            {
                PlayerPrefs.SetString("CurrentPlayer", "Male");
            }
        }

        CameraFollow script = FindObjectOfType<Camera>().GetComponent<CameraFollow>();
        script.updateScreen();
        alreadySet = true;


        if (dead && !isInvincible)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}