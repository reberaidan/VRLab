using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PauseInteractions : MonoBehaviour
{
	
	public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        //PauseMenu.SetActive(false);
    }

	public void ResumeClicked(){
		PauseMenu.SetActive(false);
	}
	
	//public void SaveClicked(){
		
	//}
	
	//public void HelpClicked(){
		
	//}
	
	public void MainMenuClicked(){
		SceneManager.LoadScene(0);
	}
}
