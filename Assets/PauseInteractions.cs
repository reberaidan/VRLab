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
	
	// Start is called before the first frame update
    public void Start()
    {
        PauseMenu.SetActive(false);
		HelpMenu.SetActive(false);
    }

	public void ResumeClicked(){
		PauseMenu.SetActive(false);
	}
	
	//public void SaveClicked(){
		
	//}
	
	public void HelpClicked(){
			HelpMenu.SetActive(true);
			PauseMenu.SetActive(false);
	}
	
	public void MainMenuClicked(){
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

