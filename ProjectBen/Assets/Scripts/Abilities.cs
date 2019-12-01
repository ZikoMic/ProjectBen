using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    private PlayerBehaviour player;
    private Rigidbody2D rb;
    [SerializeField] private float shrinkTimeLeft = 1f;
    private float shrinkSpellStart = 0f;
    [SerializeField] private float shrinkSpellCooldown = 3f;
    [SerializeField] private float invincibleTimeLeft = 1f;
    [SerializeField] private float invincibleSpellCooldown = 3f;
    public float invincibleSpellStart = 0f;
    private String currentPlayer;
    private bool isShrink = false;


// Update is called once per frame
    void FixedUpdate()
    {
        player = FindObjectOfType<PlayerBehaviour>();
        currentPlayer = PlayerPrefs.GetString("CurrentPlayer");
        rb = GameObject.FindGameObjectWithTag(currentPlayer).GetComponent<Rigidbody2D>();

//  if (PlayerPrefs.GetInt("Damage Resistance") == 2)
// {
        
        if (Time.time > shrinkSpellStart + shrinkSpellCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || isShrink)
            {
                rb.transform.localScale = new Vector3(1f, 1f, 1f);
                isShrink = true;
                Shrink();
            }
        }

        if (!isShrink)
        {
            shrinkTimeLeft = 3.0f;
        }

//   }
        if (Time.time > invincibleSpellStart + invincibleSpellCooldown)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) || player.isInvincible)
            {
                Debug.Log("Condition");
                Invincible();
            }
        }

        if (!player.isInvincible)
        {
            Debug.Log("Not invincible");
            invincibleTimeLeft = 3.0f;
        }

        Text text = GameObject.Find("Canvas/Panel/Text").GetComponent<Text>();
        text.text = "Cooldown: " + invincibleSpellCooldown;
    }

    private void Invincible()
    {
        if (invincibleTimeLeft < 0)
        {
            Debug.Log(invincibleTimeLeft);
            player.isInvincible = false;
            invincibleSpellStart = Time.time;
        }
        else if (invincibleTimeLeft > 0)
        {
            player.isInvincible = true;
            invincibleTimeLeft -= Time.deltaTime;
        }
    }

    private void Shrink()
    {
        if ((shrinkTimeLeft < 0) && (rb.transform.localScale == new Vector3(1f, 1f, 1f)))
        {
            isShrink = false;
            shrinkSpellStart = Time.time;
            rb.transform.localScale = new Vector3(3f, 3f, 1f);
        }
        else if (shrinkTimeLeft > 0)
        {
            shrinkTimeLeft -= Time.deltaTime;
        }
    }
}