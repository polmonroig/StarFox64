using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TextSelector : MonoBehaviour {

    
    
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip moveSound; 
    
    public Text[] texts;
    public GameObject[] pointers;
    
    public float height; 
    
    private uint _pos; 
    private float _initialY;
    // Start is called before the first frame update
    void Start()
    {
        _pos = 0;
        if(texts.Length > 0)texts[_pos].color = Color.white;
       if(pointers.Length > 0)_initialY = pointers[0].transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        if (texts.Length > 0)
        {
            if (Input.GetKeyDown(KeyCode.S) && _pos < texts.Length - 1) {
                soundSource.PlayOneShot(moveSound);
                _pos++;
            }
            else if (Input.GetKeyDown(KeyCode.W) && _pos > 0) {
                soundSource.PlayOneShot(moveSound);
                _pos--; 
            }
            foreach (var t in texts) {
                t.color = Color.blue;
            }
            texts[_pos].color = Color.white;

            foreach (var pointer in pointers)
            {
                pointer.transform.position = new Vector3(pointer.transform.position.x, 
                    _initialY - height * _pos, pointer.transform.position.z);
            }
        }
        
        
    }


    public uint GetSelectedScene()
    {
        return _pos; 
         
        
    }
    
}
