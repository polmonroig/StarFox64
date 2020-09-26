using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLaser : MonoBehaviour {

    private KeyCode shootCode = KeyCode.Space; 
    [SerializeField] private GameObject laser;
    [SerializeField] private Transform target;
    [SerializeField] private Transform cameraView; 
    public float force = 20.0f;
    private float _shoots;
    
    void Start(){
    	_shoots = 0;
    }

    // Update is called once per frame
    void Update() {

    	if (_shoots > 0){
    		_shoots -= 1;
    		// instantiate a new laser at current position 
            var outLaser = Instantiate(laser, target.position, Quaternion.identity);
            // must have a rigid body 
            // apply a force to the laser
            var rigidBody =  outLaser.GetComponent<Rigidbody>();
            Vector3 direction = (target.position - cameraView.position).normalized; 
            rigidBody.AddForce(direction * force);
    	}
        
        else if (Input.GetKeyDown(shootCode)) {
        	_shoots = 4;
            // instantiate a new laser at current position 
            var outLaser = Instantiate(laser, target.position, Quaternion.identity);
            // must have a rigid body 
            // apply a force to the laser
            var rigidBody =  outLaser.GetComponent<Rigidbody>();
            Vector3 direction = (target.position - cameraView.position).normalized; 
            rigidBody.AddForce(direction * force);
        }
    }
}