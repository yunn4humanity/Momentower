using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScript : MonoBehaviour {

	public AudioSource BGM;
	public AudioClip wind;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			BGM.clip = wind;
			BGM.Play ();
		}

	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			BGM.Stop ();
		}

	}
}
