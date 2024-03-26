using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Returning : MonoBehaviour
{
	[SerializeField] private GameObject VRRig;
	private Vector3 vrOrigin;
	[SerializeField] private GameObject otherObject;
	private Vector3 otherOrigin;

	private void Start()
	{
		vrOrigin = VRRig.transform.position;	
		otherOrigin = otherObject.transform.position;
	}
	private void OnTriggerEnter(Collider other)
	{
		print("exiting bounds");
		if (other.CompareTag("MainCamera")){
			print("headset");
			VRRig.transform.position = vrOrigin;
		}
		else if(other.CompareTag("Equipment"))
		{
			print(other.name);
			other.transform.position = otherOrigin;
		}
	}
}
