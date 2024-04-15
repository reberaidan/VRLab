using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] public List<GameObject> instructions;
    [SerializeField] private FeedbackRecorder feedbackRecorder;
    [SerializeField] private ColorMixing centerBeaker;
    private int currentStep = 0;
    private bool feedbackGiven = false;
    // Start is called before the first frame update
    void Start()
    {
		
        foreach (var instr in instructions)
        {
            instr.gameObject.SetActive(false);
        }
        // set first to true
        instructions[0].SetActive(true);
    }

    public bool flip(int completedInstruction)
    {
        if(completedInstruction == currentStep && !feedbackGiven){
            if(currentStep == instructions.Count-1)
            {
                feedbackRecorder.startFeedback();
                feedbackGiven = true;
                return true;
            }
            instructions[currentStep].SetActive(false);
            instructions[currentStep+1].SetActive(true);
            currentStep++;
            if (currentStep == instructions.Count - 1) { centerBeaker.targetColor.Clear(); }
            return true;
        }
        return false;

    }
	
	public bool tutorialCase(){
		// if we are in the tutorial, then open the feedback upon completing the tutorial
		if(feedbackGiven == false){
			feedbackRecorder.tutorialFeedback();
		}
		feedbackGiven = true;
		return true;
	}
}
