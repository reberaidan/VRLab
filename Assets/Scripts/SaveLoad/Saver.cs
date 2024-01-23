using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SSSoftware.Save; 

public class Saver : MonoBehaviour
{
    [SerializeField] private string saveName = "mysave"; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSaveClick()
	{
        //get lab name + date time

        Scene scene = SceneManager.GetActiveScene();

        Save save = new Save(saveName);
        save.Scene(scene);

	}

    public void OnLoadClick()
	{
		SceneManager.LoadScene("LoadLab");

	}
}
