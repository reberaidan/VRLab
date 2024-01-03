using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject lessonMenu;
    public GameObject titleMenu;

	private void Start()
	{
        lessonMenu.SetActive(false);
	}
	public void CreateClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadClicked()
    {
        titleMenu.SetActive(false);
        lessonMenu.SetActive(true);
    }

    public void ExitClicked() 
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void BackClicked()
	{
        lessonMenu.SetActive(false);
        titleMenu.SetActive(true);
	}
}
