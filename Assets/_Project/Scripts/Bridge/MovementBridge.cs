using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBridge : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D bridgeRb;

    private void Initialization()
    {
        gameManager = FindObjectOfType(typeof(GameManager)) as GameManager;
        bridgeRb = GetComponent<Rigidbody2D>();

        bridgeRb.velocity = new(gameManager.objectsSpeed, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    // Update is called once per frame
    void Update()
    {
        AutoDestruction();
    }

    private void AutoDestruction()
    {
        if(transform.position.x < gameManager.limitDestruction)
        {
            Destroy(gameObject);
        }
    }
}
