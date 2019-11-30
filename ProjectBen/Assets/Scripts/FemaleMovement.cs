using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class FemaleMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (PlayerPrefs.GetString("CurrentPlayer") == "Female")
        {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
            }

            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }

            if (Input.GetAxis("Horizontal") != 0)
            {
                anim.SetBool("isRunning", true);
            }
            else if (Input.GetAxis("Horizontal") == 0)
            {
                anim.SetBool("isRunning", false);

            }
        }
        

    }
    void FixedUpdate ()
    {
        if (PlayerPrefs.GetString("CurrentPlayer") == "Female")
        {
            // Move our character
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
    }

}
