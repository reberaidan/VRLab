using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
