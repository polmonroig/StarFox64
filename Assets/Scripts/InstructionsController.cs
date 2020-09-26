using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour {
     [SerializeField] private MenuManager _manager; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _manager.ChangeScene(MenuManager.MenuState.MenuSelector);
        }
    }
}
