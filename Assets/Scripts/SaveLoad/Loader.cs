using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SSSoftware.Save;

public class Loader : MonoBehaviour
{
    [SerializeField] private string saveName = "mysave";


    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        Load load = new Load(saveName);
        load.Scene(scene);
        load.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
