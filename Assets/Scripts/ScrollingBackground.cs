using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {


    public float speed = 0.5f; 
    
    private Material mat; 
    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material; 
    }

    // Update is called once per frame
    void Update()
    {
        mat.mainTextureOffset = new Vector2(mat.mainTextureOffset.x + Time.deltaTime * speed, mat.mainTextureOffset.y);
    }
}
