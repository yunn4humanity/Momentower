using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceFloorScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			collider.gameObject.GetComponent<CharacterController> ().onIce = true;
			//collider.collider.sharedMaterial.friction = 0;
		}
			
	}

	void OnCollisionExit2D(Collision2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			collider.gameObject.GetComponent<CharacterController> ().onIce = false;
			//collider.collider.sharedMaterial.friction = 1;
		}
			
	}
}
