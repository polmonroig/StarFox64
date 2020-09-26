using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnRadius : MonoBehaviour {


    
    public float radius = 1000.0f;

    private Vector3 initialPos; 
    
    void Start() {
        initialPos = transform.position; 
    }

    
    void Update()
    {

        var diff = (transform.position - initialPos);
        if(diff.magnitude >= radius)Destroy(this.gameObject);
    }
}
