using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEditor;
using UnityEngine.SceneManagement;
public class ExitFeedback : MonoBehaviour
{
	public GameObject Feedback;
    void Start()
    {
        
    }

    public void ExitClicked(){
		Feedback.SetActive(false);
	}
}
