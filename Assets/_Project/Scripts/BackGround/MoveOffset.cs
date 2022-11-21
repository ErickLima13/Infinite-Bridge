using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Renderer meshRenderer;
    private Material currentMaterial;

    private float offset;

    public float speed;
    public float incrementOffset;

    public string sortingLayer;
    public int orderInLayer;

    private void Initialization()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = sortingLayer;
        meshRenderer.sortingOrder = orderInLayer;
        currentMaterial = meshRenderer.material;
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialization();
    }

    private void FixedUpdate()
    {
        Parallax();
    }

    private void Parallax()
    {
        offset += incrementOffset;

        currentMaterial.mainTextureOffset = new(offset * speed, 0);
    }
}
