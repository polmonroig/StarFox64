using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {


    [SerializeField] private Text scoreText;
    private float score = 0;

    public float scorePerFrame = 3f; 

    void Update()
    {
        scoreText.text = (Convert.ToInt32(score)).ToString();
        score += scorePerFrame * Time.deltaTime; 
    }

    public void AddScore(float s)
    {
        score += s; 
    }
    
}
