
using UnityEngine;
using UnityEngine.SceneManagement;
using SSSoftware.Save;

public class Loader : MonoBehaviour
{
    [SerializeField] private string saveName = "mysave.sav";


    // Start is called before the first frame update
    void Start()
    {
        if (Load.Exists(saveName))
        {
            Scene scene = SceneManager.GetActiveScene();

            Load load = new Load(saveName);
            load.Scene(scene);
            load.Close();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
