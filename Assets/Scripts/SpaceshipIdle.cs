using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipIdle : MonoBehaviour {


    public Vector3 rotationAxis = new Vector3(0, 1, 0);
    public float rotationSpeed = 0.05f; 
    // Update is called once per frame
    void Update() {
        transform.Rotate(rotationAxis, rotationSpeed);
    }
}
