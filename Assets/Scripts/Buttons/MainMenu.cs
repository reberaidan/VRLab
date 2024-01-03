using UnityEngine;
using UnityEditor;

public class MainMenu : MonoBehaviour
{

    public void CreateClicked()
    {
        //do creating stuff. Will likely load new menu before loading in a new scene.
    }

    public void LoadClicked()
    {
        //do loading stuff. Will likely load in a new menu for loading lessons
    }

    public void ExitClicked() {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
