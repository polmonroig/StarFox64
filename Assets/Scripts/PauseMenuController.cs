using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {

    // objects to be paused 

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseMenu; 

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            if (pauseMenu.activeSelf) {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                audioSource.Play();
            }
            else {
                audioSource.Stop();
                Time.timeScale = 0; 
                pauseMenu.SetActive(true);
            }
        }
        
    }



    
}
