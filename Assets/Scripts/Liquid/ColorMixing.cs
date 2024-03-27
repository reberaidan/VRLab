using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixing : MonoBehaviour
{

    public List<Color> mColors = new List<Color>();

    public List<Color> targetColor = new List<Color>();

    private int currentStep = 0;

    [SerializeField] ClipBoard clipboard;

    [SerializeField] private Material empty;
    [SerializeField] private Material filled;
	// Start is called before the first frame update

	private void OnTriggerEnter(Collider other)
	{
        print(other.name);
        if (other.gameObject.CompareTag("pipette"))
        {
            if (other.gameObject.GetComponent<Pipette>().isFilled && gameObject.CompareTag("HoldingBeaker"))
            {
                mColors.Add(other.gameObject.GetComponent<Renderer>().material.color);
                gameObject.GetComponent<MeshRenderer>().material.color = getColor();
                if (targetColor[currentStep]== mColors[mColors.Count-1] || targetColor == mColors)
                {
                    if (clipboard.flip(currentStep))
                    {
                        currentStep++;
                    }
                }
            }
            GameObject.Find("AI Manager").GetComponent<FeedbackRecorder>().incrementLiquidMixed();

        }
        else if (other.gameObject.CompareTag("cleaning"))
        {
            cleanGlass();
			if (targetColor.Count == mColors.Count)
			{
				if (clipboard.flip(clipboard.instructions.Count-1))
				{
					currentStep++;
				}
			}
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

	private Color getTargetColor()
	{

		float red = 0;
		float green = 0;
		float blue = 0;
		float alpha = 0;
		foreach (var c in targetColor)
		{
			red += c.r;
			green += c.g;
			blue += c.b;
			alpha += c.a;
		}
		red /= targetColor.Count;
		green /= targetColor.Count;
		blue /= targetColor.Count;
		alpha /= targetColor.Count;

		Color returnColor = new Color(red, green, blue, alpha);

		return returnColor;
	}

	public void cleanGlass()
    {
		mColors.Clear();
		gameObject.GetComponent<MeshRenderer>().material = empty;
	}

    public bool confirmColor()
    {
        var current = getColor();
        var target = getTargetColor();
        return current == target;
    }

    public void addTargetColor(Color addingTarget)
    {
        targetColor.Add(addingTarget);
    }
}
