using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLimits : MonoBehaviour {

    // limited box 
    public float leftLimit;
    public float rightLimit;
    public float upperLimit;
    public float lowerLimit; 

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);
        pos.y = Mathf.Clamp(pos.y, lowerLimit, upperLimit);
        transform.position = pos; 

    }
}
