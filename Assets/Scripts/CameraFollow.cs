using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] private SpaceshipController controller; 
    [SerializeField] private Transform target; 
    public float minRotation = -10f;
    public float maxRotation = 10f;
    public float minPosY = 5f;
    public float maxPosY = 15f;
    public float minPosX = -5f;
    public float maxPosX = 5f; 
    public float rotationSpeed = 1f;
    public float movementSpeed = 4f;



    // Update is called once per frame
    void LateUpdate() {

            Vector3 pos = Vector3.Lerp(transform.position, target.position, Time.deltaTime * movementSpeed);
            pos.x = Mathf.Clamp(pos.x, minPosX, maxPosX);
            pos.y = Mathf.Clamp(pos.y, minPosY, maxPosY);
            transform.position = pos;
            if (!controller.Rolling()) {
                transform.rotation =  Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * rotationSpeed);
                Vector3 rot = transform.localRotation.eulerAngles;
                rot.z = (rot.z > 180) ? rot.z - 360 : rot.z;
                rot.z = Mathf.Clamp(rot.z, minRotation, maxRotation);
                transform.localRotation = Quaternion.Euler(rot);
            }
            
        
        
    }
}
