using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D playerRb;

    private Vector2 inputs;

    [Range(1,5)] public float speed;

    public float[] limits;

    private void Initialization()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        inputs.x = Input.GetAxisRaw("Horizontal");
        inputs.y = Input.GetAxisRaw("Vertical");

        playerRb.velocity = inputs * speed;

        MovementLimits();
        Flip(); 
    }

    private void Flip()
    {
        if (inputs.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void MovementLimits()
    {
        float posY = transform.position.y;
        float posX = transform.position.x;

        if(transform.position.y > limits[0])
        {
            posY = limits[0];
        }
        else if(transform.position.y < limits[1])
        {
            posY = limits[1];
        }

        if (transform.position.x > limits[2])
        {
            posX = limits[2];
        }
        else if (transform.position.x < -limits[2])
        {
            posX = -limits[2];
        }

        transform.position = new(posX, posY, 0);
    }
}
