using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipette : MonoBehaviour
{
    [SerializeField] private Material empty;
    [SerializeField] private Material filled;
	private Color originalColor;
    public bool isFilled = false;
	// Start is called before the first frame update
	private void Start()
	{
		originalColor = gameObject.GetComponent<MeshRenderer>().material.color;
	}
	private void OnTriggerEnter(Collider other)
	{
		Material color;
		if (other.gameObject.CompareTag("BaseLiquid"))
		{
			isFilled = true;
			color = other.gameObject.GetComponent<MeshRenderer>().material;
			var colorCode = color.color;
			gameObject.GetComponent<MeshRenderer>().material = filled;
			gameObject.GetComponent<MeshRenderer>().material.color = colorCode;
			print(colorCode);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("HoldingBeaker"))
		{
			isFilled = false;
			gameObject.GetComponent<MeshRenderer>().material.color = originalColor;

		}
	}
	
}
