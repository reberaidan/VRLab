using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject lessonMenu;
    public GameObject titleMenu;
	public GameObject tutorialPrep;
	public GameObject lab1Prep;

	private void Start()
	{
        lessonMenu.SetActive(false);
		tutorialPrep.SetActive(false);
		lab1Prep.SetActive(false);
	}

    public void LoadClicked()
    {
        titleMenu.SetActive(false);
        lessonMenu.SetActive(true);
    }
	
	public void TutorialLabClicked(){
		lessonMenu.SetActive(false);
		tutorialPrep.SetActive(true);
	}

	public void Lab1Clicked(){
		lessonMenu.SetActive(false);
		lab1Prep.SetActive(true);
	}
	
	public void MainMenuClicked(){
		lessonMenu.SetActive(false);
		titleMenu.SetActive(true);
	}
	
	public void ReturnClicked(){
		tutorialPrep.SetActive(false);
		lab1Prep.SetActive(false);
		lessonMenu.SetActive(true);
	}
	
	public void BeginClicked(){
		if (tutorialPrep.activeSelf){
			SceneManager.LoadScene("TutorialLab");
		}
		
		if (lab1Prep.activeSelf){
			SceneManager.LoadScene("Lab1");
		}
	}

    public void ExitClicked() 
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}