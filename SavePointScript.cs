using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointScript : MonoBehaviour {

	GameObject savecontroller;

	void Start()
	{
		savecontroller = GameObject.Find ("tower");
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character")
			savecontroller.GetComponent<SaveController> ().collidingSavePoint = true;
			
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character")
			savecontroller.GetComponent<SaveController> ().collidingSavePoint = false;

	}
}
