using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using UnityEngine.UI;
using System.IO.Enumeration;

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

    [SerializeField] Text returnFeedback;

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
            targetColors.Add(sceneMaterials[UnityEngine.Random.Range(0, sceneMaterials.Count)]);
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
	}

    public void verifyLiquid(Color verifying)
	{
		feedback.incrementLiquidMixed();
        //if correct liquid mixture
        if(verifying == targetMixtures[currentStep])
		{
            currentStep++;
            //if current beaker is complete
            if(currentStep == totalLiquids)
			{
                currentStep = 0;
                currentMixture++;
                //if all beakers are complete, otherwise make a new mixture
                if(currentMixture == totalMixtures)
				{
                    feedback.startFeedback();
				}
				else
				{
                    generateTargetColors();
				}
			}
            setClipboardInstructions();
		}
        
	}

    private void setClipboardInstructions()
	{
        if(currentMixture >= totalMixtures)
        {
            clipboard.text = "The lab has been completed! Make sure you clean out your beakers in the sink. Afterwards, explore the lab space and take a look at your feedback on the screen!";
            return;
        }
        
        if(currentStep == 0 && currentMixture == 0)
		{
            clipboard.text = "In this lab, you will be mixing different liquids together to see the effects of color mixing.\n\n" + 
                                "Mixtures: " + (currentMixture+1).ToString() + "/" + (totalMixtures).ToString() + 
                                "\nLiquid: " + (currentStep+1).ToString() + "/" + (totalLiquids).ToString() +
                                "\nWith a clean beaker, use the pipette to add the liquid from the " + targetColors[0].name + " beaker.\n" +
                                "Current Mixture: ";
			for (int i = 0; i <= currentStep; i++)
			{
				clipboard.text += targetColors[i].name + " ";
			}
		}
        else if(currentStep == 0)
		{
            clipboard.text = "Mixtures: " + (currentMixture + 1).ToString() + "/" + (totalMixtures).ToString() +
								"\nLiquid: " + (currentStep + 1).ToString() + "/" + (totalLiquids).ToString() +
								"\nWith a clean beaker, use the pipette to add the liquid from the " + targetColors[0].name + " beaker.\n" +
								"Current Mixture: ";
			for (int i = 0; i <= currentStep; i++)
			{
				clipboard.text += targetColors[i].name + " ";
			}
		}
        else if(currentMixture == totalMixtures-1 && currentStep == totalLiquids-1)
		{
            clipboard.text = "Mixtures: " + (currentMixture + 1).ToString() + "/" + (totalMixtures).ToString() +
								"\nLiquid: " + (currentStep + 1).ToString() + "/" + (totalLiquids).ToString() + 
                                "\nWith your beaker, use the pipette to add the liquid from the " + targetColors[currentStep].name + " beaker.\n" + 
								"Current Mixture: ";
			for (int i = 0; i <= currentStep; i++)
			{
				clipboard.text += targetColors[i].name + " ";
			}
		}
        else if(currentStep == totalLiquids - 1)
		{
            clipboard.text = "Mixtures: " + (currentMixture + 1).ToString() + "/" + (totalMixtures).ToString() +
								"\nLiquid: " + (currentStep + 1).ToString() + "/" + (totalLiquids).ToString() + 
                                "\nWith your beaker, use the pipette to add the liquid from the " + targetColors[currentStep].name + " beaker.\n\nThis will be your final liquid before a new mixture.\n" +
								"Current Mixture: ";
			for (int i = 0; i <= currentStep; i++)
			{
				clipboard.text += targetColors[i].name + " ";
			}
		}
		else
		{
            clipboard.text = "Mixtures: " + (currentMixture + 1).ToString() + "/" + (totalMixtures).ToString() +
								"\nLiquid: " + (currentStep + 1).ToString() + "/" + (totalLiquids).ToString() +
								"\nWith your beaker, use the pipette to add the liquid from the " + targetColors[currentStep].name + " beaker.\n" +
								"Current Mixture: ";
			for(int i = 0; i <=currentStep; i++)
            {
				clipboard.text += targetColors[i].name + " ";
			}
		}
	}

    public void resubmitFeedback()
    {
        feedback.resubmitFeedback();
    }

    public void exitLab()
    {
        var fileName = DateTime.Now.ToString("g") + ".txt";
#if UNITY_EDITOR
        string pathy = Application.dataPath + "/" + fileName;
#else
        string pathy = Application.persistentDataPath + "/" + fileName;
#endif
        try
        {
            if(!File.Exists(fileName))
            {
                File.WriteAllText(pathy, returnFeedback.text);
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        SceneManager.LoadScene(0);
    }

    public int getTotalMixtures()
    {
        return totalMixtures;
    }

    public int getTotalSteps()
    {
        return totalLiquids;
    }

}
