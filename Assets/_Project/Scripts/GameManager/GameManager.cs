using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Settings")]
    [Range(1, 5)] public float speed;
    public float[] limits;

    [Header("Objects Settings")]
    public float objectsSpeed;
    public float limitDestruction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
