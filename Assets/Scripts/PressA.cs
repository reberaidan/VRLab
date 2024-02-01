using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressA : MonoBehaviour
{
	
	public InputActionReference pressButton;
	public GameObject PauseMenu;
	public GameObject HelpMenu;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void OnEnable(){
		pressButton.action.performed += OpenPause;
		pressButton.action.Enable();
	}
	
	public void OnDisable(){
		pressButton.action.performed -= OpenPause;
		pressButton.action.Disable();
	}
	
	public void OpenPause(InputAction.CallbackContext obj){
		PauseMenu.SetActive(true);
		HelpMenu.SetActive(false);
	}
	
	

    // Update is called once per frame
    void Update()
    {
        
    }
}