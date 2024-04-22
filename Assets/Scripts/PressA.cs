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

	public bool isPaused = false;
	
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

		isPaused = !isPaused;
		PauseMenu.SetActive(isPaused);
		HelpMenu.SetActive(false);
		var labEquipment = GameObject.FindGameObjectsWithTag("Equipment");
		foreach (var item in labEquipment)
		{
			var comp = item.GetComponent<XRGrabInteractable>();
			if (comp != null)
			{
				comp.enabled = !isPaused;
			}
		}
	}

	public void ResumeClicked()
	{
		isPaused = !isPaused;
		PauseMenu.SetActive(isPaused);
		HelpMenu.SetActive(false);
		var labEquipment = GameObject.FindGameObjectsWithTag("Equipment");
		foreach (var item in labEquipment)
		{
			var comp = item.GetComponent<XRGrabInteractable>();
			if (comp != null)
			{
				comp.enabled = !isPaused;
			}
		}

	}



	// Update is called once per frame
	void Update()
    {
        
    }
}
