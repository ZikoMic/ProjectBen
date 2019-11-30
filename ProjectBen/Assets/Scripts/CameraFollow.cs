using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class CameraFollow : MonoBehaviour
{
    private Vector2 velocity;

    public float smoothTimeY;
    public float smoothTimeX;

    public GameObject male;
    public GameObject female;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

//    private void DestroyedPlayer()
//    {
//        if (player == null)
//        {
//            if (PlayerPrefs.GetString("CurrentPlayer") == "Male")
//            {
//                PlayerPrefs.SetString("CurrentPlayer", "Female");
//                updateScreen();
//
//            }else if(PlayerPrefs.GetString("CurrentPlayer") == "Female")
//            {
//                PlayerPrefs.SetString("CurrentPlayer", "Male");
//                updateScreen();
//            }
//            
//        }
//    }

    public void updateScreen()
    {    

        if (PlayerPrefs.GetString("CurrentPlayer") == "Male")
        {
            float posX = Mathf.SmoothDamp(transform.position.x, male.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, male.transform.position.y, ref velocity.y, smoothTimeY);
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
        else if (PlayerPrefs.GetString("CurrentPlayer") == "Female")
        {
            float posX = Mathf.SmoothDamp(transform.position.x, female.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, female.transform.position.y, ref velocity.y, smoothTimeY);
            transform.position = new Vector3(posX, posY, transform.position.z);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        updateScreen();

    }
}
