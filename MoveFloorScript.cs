using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloorScript : MonoBehaviour {

	GameObject mainCamera;


	void Start()
	{
		mainCamera = GameObject.Find("Main Camera");

	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			if (collider.GetComponent<Rigidbody2D> ().velocity.y > 0)
				mainCamera.transform.position = new Vector3 (0, mainCamera.transform.position.y + 1080, -10);
			else if(collider.GetComponent<Rigidbody2D> ().velocity.y < 0)
				mainCamera.transform.position = new Vector3 (0, mainCamera.transform.position.y - 1080, -10);
		}
			
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			if (collider.GetComponent<Rigidbody2D> ().velocity.y > 0)
				mainCamera.transform.position = new Vector3 (0, mainCamera.transform.position.y + 1080, -10);
			else if(collider.GetComponent<Rigidbody2D> ().velocity.y < 0)
				mainCamera.transform.position = new Vector3 (0, mainCamera.transform.position.y - 1080, -10);
		}

	}
}
