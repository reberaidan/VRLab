using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour
{

    [SerializeField]
    FeedbackRecorder AIManager;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Equipment"))
		{
			AIManager.incrementDropped();
		}
	}

}
