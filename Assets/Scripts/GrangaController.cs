using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrangaController : MonoBehaviour {


    [SerializeField] private GameObject target; 
    
    public float speed = 10f;

    void Update()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized; 
          transform.position += dir * (speed * Time.deltaTime);      
    }
}
