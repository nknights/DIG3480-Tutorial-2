﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform startMarker;

    public Transform endMarker;

    public float speed = 1.0F;

    private float startTime;

    private float journeyLength;



    void Start()
    {
        startTime = Time.time;

        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    // Update is called once per frame
    void Update()
    {

        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);

        float distCovered = (Time.time - startTime) * speed;

        float fracJourney = distCovered / journeyLength;

        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, Mathf.PingPong(fracJourney, 1));

    }
}
