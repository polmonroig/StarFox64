using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoRotate : MonoBehaviour {

    private Quaternion _initRotation; 
    
    private void Start()
    {
        _initRotation = transform.rotation; 
    }

    void Update()
    {
        transform.rotation = _initRotation; 
    }
}
