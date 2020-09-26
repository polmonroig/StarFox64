using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameBehaviour : MonoBehaviour {

    [SerializeField] private GameObject winMenu;
    [SerializeField] private Text score; 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip winClip;

    public string currentLevel; 
    public string nextLevel;
    private bool _win = false;

    public void Update() {
        if (_win && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 1; 
            SceneManager.LoadScene(nextLevel);
        }
            
    	if (Input.GetKeyDown(KeyCode.R) && !_win)
    		SceneManager.LoadScene(currentLevel);
    }
    
    public void WinGame() {
        _win = true;
        winMenu.SetActive(true);
        Time.timeScale = 0; 
        audioSource.Stop();
        audioSource.PlayOneShot(winClip);
        score.GetComponent<CopyText>().Copy(); 
    }
    
    public void LoseGame() {
        SceneManager.LoadScene(currentLevel);
    }
   
}
