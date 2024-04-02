using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PressA : MonoBehaviour
{
	
	public InputActionReference pressButton;
	public GameObject PauseMenu;
	public GameObject HelpMenu;
	public GameObject LabEquipment;

	
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

		GameObject.Find("Lab Equipment").GetComponent<XRGrabInteractable>().enabled = false;
        GameObject.Find("NewLabEquipment").GetComponent<XRGrabInteractable>().enabled = false;
    }
	
	

    // Update is called once per frame
    void Update()
    {
        
    }
}
