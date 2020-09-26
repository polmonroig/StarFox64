using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnEnter : MonoBehaviour {

    [SerializeField] private GameBehaviour game;
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<PlayerHealth>();
        if (player != null)
        {
            game.WinGame();
        }
    }
}
