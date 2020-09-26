using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


    public enum MenuState {
        MainMenu, MenuSelector, LevelsMenu, InstructionsMenu, CreditsMenu, Gaming 
    }
    
    private MenuState _menuState;
    private uint _level; 

    public GameObject mainMenu;
    public GameObject optionsSelector;
    public GameObject levelsMenu;
    public GameObject instructionsMenu;
    public GameObject creditsMenu; 
    
    

    private void Start() {
        DeactivateMenus();
        mainMenu.SetActive(true);
        _menuState = MenuState.MainMenu;
                _level = 1; 
    }

    public void SetLevel(uint level)
    {
        _level = level; 
    }


    public void ChangeScene(MenuState scene) {
        switch (scene)
        {
            case MenuState.MainMenu:
                DeactivateMenus();
                mainMenu.SetActive(true);
                break;
            case MenuState.MenuSelector:
                DeactivateMenus();
                optionsSelector.SetActive(true);
                break;
            case MenuState.LevelsMenu:
                DeactivateMenus();
                levelsMenu.SetActive(true);
                break;
            case MenuState.InstructionsMenu:
                DeactivateMenus();
                instructionsMenu.SetActive(true);
                break;
            case MenuState.CreditsMenu:
                DeactivateMenus();
                creditsMenu.SetActive(true);
                break;
            case MenuState.Gaming:
                SceneManager.LoadScene("Level_" + _level); 
                break;
        }
        
    }

    private void DeactivateMenus()
    {
        mainMenu.SetActive(false);
        optionsSelector.SetActive(false);
        levelsMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        creditsMenu.SetActive(false);
        
    }
    
}
