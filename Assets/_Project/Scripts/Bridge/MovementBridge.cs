using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBridge : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D bridgeRb;

    private bool isInstantiated;

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
        SpawnNewBridge();
    }

    private void SpawnNewBridge()
    {
        if (!isInstantiated)
        {
            if(transform.position.x <= 0)
            {
                isInstantiated = true;
                GameObject temp = Instantiate(gameManager.bridgePrefab);
                Vector3 pos = new(transform.position.x + gameManager.sizeBridge, transform.position.y, 0);
                temp.transform.position = pos;
            }
        }
    }

    private void AutoDestruction()
    {
        if(transform.position.x < gameManager.limitDestruction)
        {
            Destroy(gameObject);
        }
    }
}
