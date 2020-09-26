using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour {

    [SerializeField] private GameObject target; 
    
    void Update() {
        var direction = (target.transform.position - transform.position).normalized;    
        transform.rotation = Quaternion.LookRotation(direction, transform.up);
        var angles = transform.localEulerAngles;
        angles.x = 0;
        angles.z = 0; 
        transform.rotation = Quaternion.Euler(angles);
    }
}
