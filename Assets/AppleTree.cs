﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    //Prefab for instantiating apples
    public GameObject applePrefab;


    //speed at which apple tree moves
    public float speed = 1f;

    //Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    //chance apple AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    //rate at which appples will be instantiated
    public float secondsBetweenAppleDrops = 1f;




    // Start is called before the first frame update
    void Start()
    {
        //dropping apples every second 

        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;

    }
    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //changing direction
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
            
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);

        }


    }
    private void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirections)
        {
            speed *= -1;
        }

    }
}
