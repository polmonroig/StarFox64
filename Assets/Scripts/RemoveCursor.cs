using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCursor : MonoBehaviour
{
    private void Awake() {
        // the game manager must persist in all the scenes 
        // DontDestroyOnLoad(gameObject); 
        // remove cursor 
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }
}
