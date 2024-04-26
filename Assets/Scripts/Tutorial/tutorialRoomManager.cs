using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialRoomManager : MonoBehaviour
{
    public void exitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
