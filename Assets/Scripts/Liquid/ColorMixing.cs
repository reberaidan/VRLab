using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMixing : MonoBehaviour
{

    private List<Color> mColors = new List<Color>();

    [SerializeField] private Material empty;
    [SerializeField] private Material filled;
	// Start is called before the first frame update

	private void OnTriggerEnter(Collider other)
	{
        print(other.name);
        if (other.gameObject.CompareTag("pipette"))
        {
            if (other.gameObject.GetComponent<Pipette>().isFilled)
            {
                mColors.Add(other.gameObject.GetComponent<Renderer>().material.color);
                gameObject.GetComponent<MeshRenderer>().material.color = getColor();
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
