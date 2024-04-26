using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TutorialScript : MonoBehaviour
{

	[SerializeField] List<string> instructions;
	[SerializeField] TextMeshProUGUI textField;
	[SerializeField] FeedbackRecorder feedbackRecorder;
	[SerializeField] GameObject controls;
	[SerializeField] GameObject backButton;

	private int currentPosition = 0;


	// Start is called before the first frame update
	void Start()
	{
		backButton.SetActive(false);
		textField.text = instructions[currentPosition];
		controls.SetActive(false);
	}

	public void NextClicked()
	{
		currentPosition++;
		if (currentPosition == instructions.Count)
		{
			//do feedback
			feedbackRecorder.tutorialFeedback();
			gameObject.SetActive(false);
		}
		else if(currentPosition == 1)
		{
			controls.SetActive(true);
			textField.text = instructions[currentPosition];
			backButton.SetActive(true);
		}
		else
		{
			controls.SetActive(false);
			textField.text = instructions[currentPosition];
			backButton.SetActive(true);
		}

	}

	public void BackClicked()
	{
		currentPosition--;
		if (currentPosition == 0)
		{
			backButton.SetActive(false); 
			textField.text = instructions[currentPosition];
			controls.SetActive(false);
		}
		else if(currentPosition == 1)
		{
			textField.text = instructions[currentPosition];
			controls.SetActive(true) ;
		}
		else
		{
			controls.SetActive(false) ;
			textField.text = instructions[currentPosition];
		}

	}
}
