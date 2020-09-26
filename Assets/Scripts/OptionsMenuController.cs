using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TextSelector))]
public class OptionsMenuController : MonoBehaviour {



    [SerializeField] private MenuManager _manager;
    private TextSelector _selector; 

    private void Start() {
        _selector = GetComponent<TextSelector>(); 
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var pos = _selector.GetSelectedScene();
            if (pos == 4) Application.Quit(); 
            else{
                
                MenuManager.MenuState state = MenuManager.MenuState.CreditsMenu;
                if (pos == 0) state = MenuManager.MenuState.Gaming;
                else if (pos == 1) state =  MenuManager.MenuState.LevelsMenu;
                else if (pos == 2) state =  MenuManager.MenuState.InstructionsMenu; 
            
                _manager.ChangeScene(state);
            }
            
        }
              
    }
}
