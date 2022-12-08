using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D playerRb;

    private Vector2 inputs;

    private void Initialization()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
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

        playerRb.velocity = inputs * gameManager.speed;

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

        if(transform.position.y > gameManager.limits[0])
        {
            posY = gameManager.limits[0];
        }
        else if(transform.position.y < gameManager.limits[1])
        {
            posY = gameManager.limits[1];
        }

        if (transform.position.x > gameManager.limits[2])
        {
            posX = gameManager.limits[2];
        }
        else if (transform.position.x < -gameManager.limits[2])
        {
            posX = -gameManager.limits[2];
        }

        transform.position = new(posX, posY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError("PUFT");
        print("BAteu");
    }
}
