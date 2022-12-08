using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerPhysics playerPhysics;

    [Header("Player Settings")]
    [Range(1, 5)] public float speed;
    public float[] limits;

    [Header("Bridge Settings")]
    public float objectsSpeed;
    public float limitDestruction;
    public float sizeBridge;
    public GameObject bridgePrefab;

    [Header("Barrel Settings")]
    public int orderTop;
    public int orderDown;
    public float posYtop;
    public float posYdown;
    public GameObject barrelPrefab;
    public float spawnTime;

    [Header("Globals")]
    public int score;
    public float posXPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerPhysics = FindObjectOfType(typeof(PlayerPhysics)) as PlayerPhysics;
        StartCoroutine(SpawnBarrel());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        posXPlayer = playerPhysics.transform.position.x;
    }

    private IEnumerator SpawnBarrel()
    {
        yield return new WaitForSeconds(spawnTime);
        float posY = 0;
        int order = 0;

        int random = Random.Range(0, 100);

        if(random < 50)
        {
            posY = posYtop;
            order = orderTop;
        }
        else
        {
            posY = posYdown;
            order = orderDown;
        }

        GameObject temp = Instantiate(barrelPrefab);
        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;

        StartCoroutine(SpawnBarrel());
    }

    public void AddScore(int value)
    {
        score += value;
    }
}
