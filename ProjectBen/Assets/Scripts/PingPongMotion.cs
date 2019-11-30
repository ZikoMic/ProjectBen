using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMotion : MonoBehaviour
{
    private Transform ThisTransform = null;

    private Vector3 OrgPos = Vector3.zero;

    public Vector3 MoveAxes = Vector2.zero;

    public float Distance = 11f;
    public float speed = 6f;

    private void Awake()
    {
        ThisTransform = GetComponent<Transform>();
        OrgPos = ThisTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ThisTransform.position = OrgPos + MoveAxes * Mathf.PingPong(Time.time * speed, Distance);
    }
}
