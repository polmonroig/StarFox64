using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FlickeringText : MonoBehaviour {


    public Color firstColor = Color.white;
    public Color secondColor = Color.red;
    public float timeLapse = 3;

    
    private Text _text;
    private bool first;
    void Start()
    {
        first = true; 
        _text = GetComponent<Text>();
        _text.color = firstColor; 
        StartCoroutine(ChangeColor());
    }



    IEnumerator ChangeColor() {
        
        while (true)
        {
            
            yield return new WaitForSeconds(timeLapse);
            if (first)
            {
                first = false; 
                _text.color = secondColor;
            }
            else {
                first = true; 
                _text.color = firstColor;
            } 
        }
        
    }
}
