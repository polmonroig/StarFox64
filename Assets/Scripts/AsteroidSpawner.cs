using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class AsteroidSpawner : MonoBehaviour {

    // the spawning area is represented by a cube
    // a cube can be represented with two 3D points
    public Vector3 minPos;
    public Vector3 maxPos;
    public float initialAsteroids = 100;
    public float speed = 200f;
    // objects to spawn
    public GameObject[] objects;

    private bool _spawn = false;

    private void Start() {
        for (int i = 0; i < initialAsteroids; ++i){
            SpawnAsteroid();
        }
    }

    // Update is called once per frame
    void Update() {
        if (!_spawn)
        {
            //StartCoroutine(Spawn());
        }

    }

    private void SpawnAsteroid()
    {
        var obj = objects[Random.Range(0, objects.Length)];
        Vector3 randPos = new Vector3(Random.Range(minPos.x, maxPos.x),
            Random.Range(minPos.y, maxPos.y),
            Random.Range(minPos.z, maxPos.z));
        var randomRotation = Quaternion.Euler(Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f), Random.Range(0.0f, 360.0f));
        obj = Instantiate(obj, randPos, randomRotation);
        var rb = obj.GetComponent<Rigidbody>();
        var direction = Vector3.forward;
        rb.AddForce(Time.deltaTime * direction * speed);
    }


    private IEnumerator Spawn() {
        _spawn = true;
        SpawnAsteroid();
        yield return new WaitForSeconds(3);
        _spawn = false;
    }


}
