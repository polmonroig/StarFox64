using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ClosingDoors : MonoBehaviour {


    public float doorSpeed = 5f; 
    
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;

    private Vector3 _centerLeftPos;
    private Vector3 _centerRightPos;
    private Vector3 _leftPos;
    private Vector3 _rightPos; 
    private float _width;
    private float _distanceMargin;
    private bool movingOut; 
    
    void Start() {
        _width = leftDoor.transform.localScale.x; // could have chosen right door  
        _centerLeftPos = leftDoor.transform.position;
        _centerRightPos = rightDoor.transform.position;
        _leftPos = _centerLeftPos;
        _rightPos = _centerRightPos;
        _leftPos.x -= _width;
        _rightPos.x += _width;
        _distanceMargin = 1;
        movingOut = true; 
    }

    // Update is called once per frame
    void Update() {

        if (movingOut) {
            leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, _leftPos, Time.deltaTime * doorSpeed);
            rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, _rightPos, Time.deltaTime * doorSpeed);
            movingOut = Vector3.Distance(leftDoor.transform.position, _leftPos) >= _distanceMargin; 
        }
        else {
            leftDoor.transform.position = Vector3.Lerp(leftDoor.transform.position, _centerLeftPos, Time.deltaTime * doorSpeed);
            rightDoor.transform.position = Vector3.Lerp(rightDoor.transform.position, _centerRightPos, Time.deltaTime * doorSpeed);
            movingOut = !(Vector3.Distance(leftDoor.transform.position, _centerLeftPos) >= _distanceMargin); 
        }

    }
}
