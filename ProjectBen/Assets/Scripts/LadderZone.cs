using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour
{
    private PlayerBehaviour player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerBehaviour>();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            player.onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            player.onLadder = false;
        }
    }
}
