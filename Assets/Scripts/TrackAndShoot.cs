using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject origin;
    [SerializeField] private Vector3 predictionPos;
    public float shootsPerCharge = 50f;
    private float _shoots;
    private bool _charging;
    private bool _followLaser = false; 
    public float force = 20.0f;
    public float attackDistance;
    public Vector3 player;

    private void Start()
    {
        _charging = false; 
        _shoots = 0;
    }

    // Update is called once per frame
    void Update() {
        if (_shoots >= shootsPerCharge && !_charging) {
            StartCoroutine(Recharge());
            _charging = true; 
        }
        else if (!_charging && Vector3.Distance(target.transform.position, origin.transform.position) < attackDistance && target.transform.position.z <= origin.transform.position.z) {
            // Shoot spaceship
            // instantiate a new laser at current position
            var outLaser = Instantiate(laser, origin.transform.position,  Quaternion.identity);
            // must have a rigid body
            // apply a force to the laser
            var rigidBody =  outLaser.GetComponent<Rigidbody>();
            // Shoot to spaceship    

            var targetPos = target.transform.position + predictionPos;
            var direction = (targetPos - origin.transform.position).normalized;
            rigidBody.AddForce(direction * force);
            
            _shoots++; 
        }
    }

    private IEnumerator Recharge() {
        yield return  new WaitForSeconds(3);
        _shoots = 0;
        _charging = false;
    }
}