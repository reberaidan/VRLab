using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningStation : MonoBehaviour
{
    [SerializeField] private ParticleSystem water;
    // Start is called before the first frame update
    void Start()
    {
        water.gameObject.SetActive(false);
    }
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("HoldingBeaker"))
		{
            water.gameObject.SetActive(true);
		}
	}
	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("HoldingBeaker"))
		{
			water.gameObject.SetActive(false);
		}
	}
}
