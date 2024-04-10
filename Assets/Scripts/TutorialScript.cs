using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
	public GameObject Tutorial;
	public GameObject BackButton;
	public GameObject Instructions1;
	public GameObject Instructions2;
	public GameObject Instructions3;
	public GameObject Instructions4;
	public GameObject Instructions5;
	public GameObject Instructions6;
	
	int i = 1;
	
    // Start is called before the first frame update
    void Start()
    {
        BackButton.SetActive(false);
		Instructions2.SetActive(false);
		Instructions3.SetActive(false);
		Instructions4.SetActive(false);
		Instructions5.SetActive(false);
		Instructions6.SetActive(false);
    }

	public void NextClicked(){
		i += 1;
		if (i > 6){
			i = 6;
		}
		if (i == 2){
			Instructions1.SetActive(false);
			Instructions2.SetActive(true);
			BackButton.SetActive(true);
		}
		if (i == 3){
			Instructions2.SetActive(false);
			Instructions3.SetActive(true);
		}
		if (i == 4){
			Instructions3.SetActive(false);
			Instructions4.SetActive(true);
		}
		if (i == 5){
			Instructions4.SetActive(false);
			Instructions5.SetActive(true);
		}
		if (i == 6){
			Instructions5.SetActive(false);
			Instructions6.SetActive(true);
		}
		
	}
	
	public void BackClicked(){
		i -= 1;
		if (i < 1){
			i = 1;
		}
		if (i == 6){
			Instructions6.SetActive(true);
		}
		if (i == 5){
			Instructions6.SetActive(false);
			Instructions5.SetActive(true);
		}
		if (i == 4){
			Instructions5.SetActive(false);
			Instructions4.SetActive(true);
		}
		if (i == 3){
			Instructions4.SetActive(false);
			Instructions3.SetActive(true);
		}
		if (i == 2){
			Instructions3.SetActive(false);
			Instructions2.SetActive(true);
		}
		
		if (i == 1){
			Instructions1.SetActive(true);
			Instructions2.SetActive(false);
			BackButton.SetActive(false);
		}
		
	}
}
