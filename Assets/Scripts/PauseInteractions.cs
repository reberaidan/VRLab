using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PauseInteractions : MonoBehaviour
{
	
	public GameObject PauseMenu;
	public GameObject HelpMenu;
	public GameObject LabEquipment;

	// Start is called before the first frame update
    public void Start()
    {
        PauseMenu.SetActive(false);
		HelpMenu.SetActive(false);
		
    }

	public void ResumeClicked(){
		PauseMenu.SetActive(false);
		GameObject.Find("Beaker water (4)").GetComponent<XRGrabInteractable>().enabled = true;
		GameObject.Find("Erlenmeyer_flask with water (3)").GetComponent<XRGrabInteractable>().enabled = true;
		GameObject.Find("florence_flask with water (1)").GetComponent<XRGrabInteractable>().enabled = true;

	}
	
	public void HelpClicked(){
			HelpMenu.SetActive(true);
			PauseMenu.SetActive(false);
	}
	
	public void MainMenuClicked(){
		GameObject.Find("Beaker water (4)").GetComponent<XRGrabInteractable>().enabled = true;
		GameObject.Find("Erlenmeyer_flask with water (3)").GetComponent<XRGrabInteractable>().enabled = true;
		GameObject.Find("florence_flask with water (1)").GetComponent<XRGrabInteractable>().enabled = true;
		SceneManager.LoadScene(0);
		
	}
	
	public void ReturnClicked(){
		HelpMenu.SetActive(false);
		PauseMenu.SetActive(true);
		
		
	}
	
	void Update()
    {
			
	}
}

