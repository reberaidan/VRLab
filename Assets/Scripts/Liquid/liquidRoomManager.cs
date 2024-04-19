using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class liquidRoomManager : MonoBehaviour
{
    [Tooltip("The liquids that will be getting mixed. Should preferably be in order from left to right from user.")]
    [SerializeField] List<GameObject> sceneMaterials;
    private List<GameObject> targetColors;
    private List<Color> targetMixtures;
    private int currentStep = 0;
    private int currentMixture = 0;
    [Tooltip("Determines the amount of liquids a beak will need until fully complete.")]
    [SerializeField] int totalLiquids;
    [Tooltip("Determines the amount of mixtures in total will be completed in the lab.")]
    [SerializeField] int totalMixtures;

    [SerializeField] TextMeshProUGUI clipboard;

    [SerializeField] FeedbackRecorder feedback;

    // Start is called before the first frame update
    void Start()
    {
        generateTargetColors();
        setClipboardInstructions();
    }

    private void generateTargetColors()
	{
        targetColors = new List<GameObject>();
        targetMixtures = new List<Color>();
        for(int i = 0; i<totalLiquids; i++)
		{
            targetColors.Add(sceneMaterials[Random.Range(0, sceneMaterials.Count)]);
            if (i == 0)
			{
                targetMixtures.Add(targetColors[0].GetComponent<MeshRenderer>().material.color);
			}
			else
			{
                float red = 0;
                float green = 0;
                float blue = 0;
                float alpha = 0;
                foreach(GameObject item in targetColors)
				{
                    var temp = item.GetComponent<MeshRenderer>().material.color;
                    red += temp.r;
                    green += temp.g;
                    blue += temp.b;
                    alpha += temp.a;
				}
                red /= targetColors.Count;
                green /= targetColors.Count;
                blue /= targetColors.Count;
                alpha /= targetColors.Count;

                targetMixtures.Add(new Color(red, green, blue, alpha));
			}
			
		}
        foreach(GameObject item in targetColors)
		{
            print(item.name);
		}
        foreach(Color item in targetMixtures)
		{
            print(item);
		}
	}

    public void verifyLiquid(Color verifying)
	{
        print(verifying);
        print(targetMixtures[currentStep]);
        if(verifying == targetMixtures[currentStep])
		{
            print("correct step");
            currentStep++;
            //tell clipboard to increment its steps. Will likely need to say which position the liquids are in.
            //add liquids mixed to feedbackrecorder
            if(currentStep == totalLiquids)
			{
                print("liquid complete");
                currentStep = 0;
                currentMixture++;
                if(currentMixture == totalMixtures)
				{
                    //do AI feedback
				}
				else
				{
                    generateTargetColors();
                    print("generating new targets");
				}
			}
            setClipboardInstructions();
		}
		else
		{
            print("not the correct mixture");
            //add liquids mixed to feedbackrecorder
		}
	}

    private void setClipboardInstructions()
	{
        if(currentStep == 0 && currentMixture == 0)
		{
            clipboard.text = "In this lab, you will be mixing different liquids together to see the effects of color mixing.\n\n" + "With a clean beaker, use the pipette to add the liquid from the " + targetColors[0].name + " beaker.";
		}
        else if(currentStep == 0)
		{
            clipboard.text = "With a clean beaker, use the pipette to add the liquid from the " + targetColors[0].name + " beaker.";
        }
        else if(currentMixture == totalMixtures-1 && currentStep == totalLiquids-1)
		{
            clipboard.text = "With your beaker, use the pipette to add the liquid from the " + targetColors[currentStep].name + "beaker.\n\nAfterwards, we are done with our equipment. Rinse out your beakers in the sink.";
		}
        else if(currentStep == totalLiquids - 1)
		{
            clipboard.text = "With your beaker, use the pipette to add the liquid from the " + targetColors[currentStep].name + "beaker.\n\nThis will be your final liquid before a new mixture.";
		}
		else
		{
            clipboard.text = "With your beaker, use the pipette to add the liquid from the " + targetColors[currentStep].name + "beaker.";
		}
	}

}
