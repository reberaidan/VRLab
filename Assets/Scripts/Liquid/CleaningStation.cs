using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class CleaningStation : MonoBehaviour
{
    [SerializeField] private ParticleSystem water;
    // Start is called before the first frame update

	private void OnTriggerEnter(Collider other)
	{
		water.Play();
	}

	private void OnTriggerExit(Collider other)
	{
		water.Stop();
	}
}
