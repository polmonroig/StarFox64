using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour {
    private void OnCollisionEnter(Collision other) {
        var destroyable = other.gameObject.GetComponent<Destroyable>();
        if (destroyable != null){
            destroyable.Explode(); 
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
