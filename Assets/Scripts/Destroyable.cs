using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour{


    public float size = 3;

    private bool destroyed = false;
    [SerializeField] private GameObject explosionPrefab;

    public void Explode(){
        if(explosionPrefab != null && !destroyed){
            var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            explosion.transform.localScale *= size;
            destroyed = true;
            Destroy(explosion, 1);
        }
    }
}
