using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float shrinkTimeLeft = 1f;
    private float shrinkSpellStart = 0f;
    [SerializeField] private float shrinkSpellCooldown = 3f;
    private bool isShrink = false;
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > shrinkSpellStart + shrinkSpellCooldown)
        {
//        PlayerPrefs.GetInt("Damage Resistance") == 2
            if (Input.GetKeyDown(KeyCode.Alpha1) || isShrink)
            {
                isShrink = true;
                rb.transform.localScale = Vector3.one;
                Shrink();
            }
        }

        if (!isShrink)
        {
            shrinkTimeLeft = 3.0f;
        }
        
    }

    private void Shrink()
    {
        if (shrinkTimeLeft < 0 && rb.transform.localScale == Vector3.one)
        {
            shrinkSpellStart = Time.time;
            isShrink = false;
            rb.transform.localScale = new Vector3(3f, 3f, 0f);
        } else if (shrinkTimeLeft > 0)
        {
            shrinkTimeLeft -= Time.deltaTime;
        }
    }
}