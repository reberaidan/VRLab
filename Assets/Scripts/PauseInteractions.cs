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
		GameObject.Find("Lab Equipment").GetComponent<XRGrabInteractable>().enabled = true;
        GameObject.Find("NewLabEquipment").GetComponent<XRGrabInteractable>().enabled = true;

    }
	
	public void HelpClicked(){
			HelpMenu.SetActive(true);
			PauseMenu.SetActive(false);
	}
	
	public void MainMenuClicked(){
		GameObject.Find("Lab Equipment").GetComponent<XRGrabInteractable>().enabled = true;
        GameObject.Find("NewLabEquipment").GetComponent<XRGrabInteractable>().enabled = true;
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

