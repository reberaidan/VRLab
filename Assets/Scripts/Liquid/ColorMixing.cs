using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixing : MonoBehaviour
{

    public List<Color> mColors = new List<Color>();

    [SerializeField] private Material empty;
    [SerializeField] private Material filled;
	// Start is called before the first frame update
	private liquidRoomManager roomManager;

	private void Start()
	{
		roomManager = GameObject.FindWithTag("roomManager").GetComponent<liquidRoomManager>();
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.CompareTag("pipette"))
        {
			if (other.gameObject.GetComponent<Pipette>().isFilled && gameObject.CompareTag("HoldingBeaker"))
			{
                print("adding liquid");
				mColors.Add(other.gameObject.GetComponent<Renderer>().material.color);
				gameObject.GetComponent<MeshRenderer>().material.color = getColor();
				roomManager.verifyLiquid(getColor());
                
				//GameObject.Find("AI Manager").GetComponent<FeedbackRecorder>().incrementLiquidMixed();
				/*if (targetColor[currentStep] == mColors[mColors.Count - 1] || targetColor == mColors)
				{
					if (clipboard.flip(currentStep))
					{
						currentStep++;
					}
				}*/
			}


		}
        else if (other.gameObject.CompareTag("cleaning"))
        {
            cleanGlass();
		}
	}

    private Color getColor()
    {

        float red = 0;
        float green = 0;
        float blue = 0;
        float alpha = 0;
        foreach(var c in mColors)
        {
            red += c.r;
            green += c.g;
            blue += c.b;
            alpha += c.a;
        }
        red /= mColors.Count;
        green /= mColors.Count;
        blue /= mColors.Count;
        alpha /= mColors.Count;

        Color returnColor = new Color(red, green, blue, alpha);

        return returnColor;
    }

	public void cleanGlass()
    {
		mColors.Clear();
		gameObject.GetComponent<MeshRenderer>().material = empty;
	}


}
