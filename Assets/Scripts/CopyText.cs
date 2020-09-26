using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyText : MonoBehaviour {

    public Text copy;
    private Text _current;
    


    public void Copy() {
        _current = GetComponent<Text>();
        _current.text = copy.text; 
    }
}
