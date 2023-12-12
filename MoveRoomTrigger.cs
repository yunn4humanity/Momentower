using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoomTrigger : MonoBehaviour {

	GameObject groundscenemanager;
	public bool left;

	void Start()
	{
		groundscenemanager = GameObject.Find ("GroundSceneManager");

	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.name == "character")
			groundscenemanager.GetComponent<GroundSceneManager> ().changeRoom (this.transform.parent.gameObject,left);
	}
}
