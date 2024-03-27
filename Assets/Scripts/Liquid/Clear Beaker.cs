using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBeaker : MonoBehaviour
{
	private void OnParticleCollision(GameObject other)
	{
		print(other.name);
		if (other.CompareTag("HoldingBeaker"))
		{
			other.gameObject.GetComponent<ColorMixing>().cleanGlass();
		}
	}
}
