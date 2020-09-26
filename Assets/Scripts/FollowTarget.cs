using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {


    public Vector3 offset; 
    public Transform target;
    public float speed;
    public float waitTime = 15f;
    private bool _follow = false;

    private void Start()
    {
        StartCoroutine(WaitToStart());
    }

    void Update() {
        if(_follow)
            transform.position = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
    }

    private IEnumerator WaitToStart() {
        yield return new WaitForSeconds(waitTime);
        _follow = true; 
    }
}
