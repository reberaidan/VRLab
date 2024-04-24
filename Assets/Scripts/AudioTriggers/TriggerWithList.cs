using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerTrigger : MonoBehaviour
{
	[SerializeField] private List<AudioClip> clips = new List<AudioClip>();
	private AudioSource source;

	private void Start()
	{
		source = gameObject.GetComponent<AudioSource>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag("pipette"))
		{
			source.clip = clips[Random.Range(0, clips.Count)];
			source.Play();
		}
	}
}
