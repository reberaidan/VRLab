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
		GameObject.Find("Fade").GetComponent<Animator>().ResetTrigger("FadeOut");
		PauseMenu.SetActive(false);
		HelpMenu.SetActive(false);
		
    }

	//moved reference to PressA function to keep consistency - Aidan
	/*public void ResumeClicked(){
		PauseMenu.SetActive(false);
		var labEquipment = GameObject.FindGameObjectsWithTag("Equipment");
		foreach (var item in labEquipment)
		{
			item.GetComponent<XRGrabInteractable>().enabled = true;
		}

    }*/
	
	public void HelpClicked(){
			HelpMenu.SetActive(true);
			PauseMenu.SetActive(false);
	}
	
	public void MainMenuClicked(){
		//Unsure why we are re-enabling grabbing if we are going back to the main menu. - Aidan
		/*
				GameObject.Find("Lab Equipment").GetComponent<XRGrabInteractable>().enabled = true;
				GameObject.Find("NewLabEquipment").GetComponent<XRGrabInteractable>().enabled = true;*/

		StartCoroutine("fadeOutMainMenu");
		
	}

	IEnumerator fadeOutMainMenu()
	{
		GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeOut");
		yield return new WaitForSeconds(2);
		PauseMenu.SetActive(false);
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

