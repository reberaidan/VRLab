using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] public List<GameObject> instructions;
    [SerializeField] private FeedbackRecorder feedbackRecorder;
    [SerializeField] private ColorMixing centerBeaker;
    private int currentStep = 0;
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
        print("determining to flip");
        if(completedInstruction == currentStep){
            print(currentStep);
            print(instructions.Count - 1);
            if(currentStep == instructions.Count-1)
            {
                feedbackRecorder.startFeedback();
                return true;
            }
            instructions[currentStep].SetActive(false);
            instructions[currentStep+1].SetActive(true);
            currentStep++;
            if (currentStep == instructions.Count - 1) { centerBeaker.targetColor.Clear(); }
            return true;
        }
        print("not flipping");
        return false;

    }
}
