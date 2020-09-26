using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {


    [SerializeField] private GameBehaviour game;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Image healthFill; 
    public float health;
    private Slider healthSlider;
    private bool _godMode; 
    private readonly Color _normalColor = new Color(0.83f, 0.196f, 0.196f, 1);
    private readonly Color _godColor = new Color(0.98f, 0.94f, 0.19f, 1);

    private void Start()
    {
        healthSlider = healthBar.GetComponent<Slider>();
        _godMode = false; 
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            healthFill.color = _godMode ? _normalColor : _godColor;

            _godMode = !_godMode;
        } 
        healthSlider.value = health; 
        if(health <= 0)game.LoseGame();
    }

    public void reduce(float value) {
        if(!_godMode) health -= value; 
    }

    
    
}
