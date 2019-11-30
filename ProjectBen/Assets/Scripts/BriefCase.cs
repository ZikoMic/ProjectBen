using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BriefCase : MonoBehaviour
{
    Rigidbody2D rgbdy;
    int speed =  3;
    public int direction;
    public void Start()
    {
        rgbdy = gameObject.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        rgbdy.MovePosition(rgbdy.transform.position += transform.right * direction * speed *Time.deltaTime
            );
    }
}
