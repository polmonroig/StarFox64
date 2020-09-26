using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoints : MonoBehaviour {
   
    
    private PlayerScore _score;

    private void Start()
    {
        _score = GameObject.FindWithTag("Player").GetComponent<PlayerScore>(); 
    }

    private void Update()
    {
        if(_score == null)_score = GameObject.FindWithTag("Player").GetComponent<PlayerScore>();
    }


    public float additive; 
    
    private void OnCollisionEnter(Collision other) {
        if (_score != null)
        {
            var playerLaser = other.gameObject.GetComponent<AdditiveLaser>(); 
            if(playerLaser != null)
            _score.AddScore(additive);
        }
        
    }
}
