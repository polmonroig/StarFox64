using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipController : MonoBehaviour {


    private float _horInput;
    private float _vertInput;
    private readonly Color _original = new Color(0.3113208f, 0.4540634f, 1, 1); 
    private readonly Color _inactive = Color.gray;
    private float _breakForce;
    private float _accelerationForce;
    private bool _canApplyForce;
    private bool _rolling;
    private float _rollingAngle;
    private const float COMPLETE_ROLL = 360f; 
    
    [SerializeField] private Text forceText;
    [SerializeField] private float minRotation = -45f;
    [SerializeField] private float maxRotation = 45f;
    [SerializeField] private Vector3 direction;
    
    public float rotSpeed = 60f;
    public float movementSpeed = 20.0f;
    public float gravity = -2.0f;
    public float rotationGravity = 30f;
    public float secondsBetweenForces = 8f;
    public float forceDuration = 2f;
    // ROLLING VARIABLES 
    public float totalRolls = 2f;
    public float rollSpeed = 15f; // roll speed is angles per frame 
    
    private void Start() {
        _rollingAngle = 0; 
        _rolling = false; 
        _canApplyForce = true; 
        direction = (direction - transform.position).normalized;
        _breakForce = 1;
        _accelerationForce = 1; 
    }
    

    void Update() {
        _horInput = Input.GetAxis("Horizontal");
        _vertInput = -Input.GetAxis("Vertical"); // due to game design control is inverted
        // the spaceship movement is simply based on 
        // the pitch, yaw and roll movements 
        RollEffect(); 
        if (!_rolling) {
            Pitch(); // up or down 
            Roll(); // move sideways 
            ApplyBreak(); 
        }
        
        Forward(); // move forward 
        
    }

    public bool Rolling()
    {
        return _rolling; 
    }

    private void RollEffect() {
        if (_rolling) {
            RollRotate();
        }
        else if(Input.GetKeyDown(KeyCode.E)) {
            _rolling = true;
            RollRotate(); 
        }
    }

    private void RollRotate() {
        transform.Rotate(new Vector3(0, 0, 1), rollSpeed * Time.deltaTime);
        _rollingAngle += rollSpeed * Time.deltaTime;
        transform.position += new Vector3(Time.deltaTime * movementSpeed * _horInput, 0, 0);
        transform.position += new Vector3(0, Time.deltaTime * movementSpeed * _vertInput, 0);
        if (_rollingAngle >= COMPLETE_ROLL * totalRolls) {
            _rolling = false;
            _rollingAngle = 0; 
        }
    }
    
    

    private void ApplyBreak() {
        if (Input.GetKeyDown(KeyCode.F) && _canApplyForce)
        {
            _breakForce = 0.4f;
            _canApplyForce = false; 
            forceText.color = _inactive; 
            StartCoroutine(WaitToBreak());
            StartCoroutine(WaitForForceRecharge()); 
        }

        if (Input.GetKeyDown(KeyCode.B) && _canApplyForce)
        {
            _accelerationForce = 1.8f;
            _canApplyForce = false;
            forceText.color = _inactive; 
            StartCoroutine(WaitToAccelerate());
            StartCoroutine(WaitForForceRecharge()); 
        }
    }

    private IEnumerator WaitForForceRecharge() {
        yield return new WaitForSeconds(secondsBetweenForces);
        _canApplyForce = true;
        forceText.color = _original; 
    }
    
    private IEnumerator WaitToAccelerate()
    {
        yield return new WaitForSeconds(forceDuration);
        _accelerationForce = 1; 
    }
    
    private IEnumerator WaitToBreak()
    {
        yield return new WaitForSeconds(forceDuration);
        _breakForce = 1; 
    }
    
    
    

    private void Pitch() {
        if (_vertInput != 0) {
            transform.position += new Vector3(0, Time.deltaTime * movementSpeed * _vertInput, 0);
            transform.Rotate(new Vector3(1, 0, 0), -_vertInput * rotSpeed * Time.deltaTime);
            Vector3 rot = transform.localRotation.eulerAngles;
            rot.x = (rot.x > 180) ? rot.x - 360 : rot.x;
            rot.x = Mathf.Clamp(rot.x, minRotation, maxRotation);
            rot.y = 0; 
            transform.localRotation = Quaternion.Euler(rot);
        }
        else {
            transform.position += new Vector3(0, 1, 0) * (gravity * Time.deltaTime);
            Quaternion idleQuaternion = transform.rotation;
            idleQuaternion.x = 0; 
            transform.rotation = Quaternion.Lerp(transform.rotation, idleQuaternion, rotationGravity *Time.deltaTime);
        }
    }

    private void Roll() {
        if (_horInput != 0) {
            transform.position += new Vector3(Time.deltaTime * movementSpeed * _horInput, 0, 0); 
            transform.Rotate(new Vector3(0, 0, 1), -_horInput * rotSpeed * Time.deltaTime);
            Vector3 rot = transform.localRotation.eulerAngles;
            rot.z = (rot.z > 180) ? rot.z - 360 : rot.z;
            rot.z = Mathf.Clamp(rot.z, minRotation, maxRotation);
            rot.y = 0; 
            transform.localRotation = Quaternion.Euler(rot);
        }
        else {
            Quaternion idleQuaternion = transform.rotation;
            idleQuaternion.z = 0; 
            transform.rotation = Quaternion.Lerp(transform.rotation, idleQuaternion, rotationGravity *Time.deltaTime);
        }
    }
    

    

    private void Forward() {
        transform.position += direction * (_breakForce * movementSpeed * Time.deltaTime * _accelerationForce); 
    }


}
