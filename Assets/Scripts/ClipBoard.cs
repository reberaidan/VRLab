using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipBoard : MonoBehaviour
{
    [SerializeField] private List<GameObject> instructions;
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

    public void flip(int completedInstruction)
    {
        if(completedInstruction == currentStep){
            instructions[currentStep].SetActive(false);
            instructions[currentStep+1].SetActive(true);
            currentStep++;
        }

    }
}
