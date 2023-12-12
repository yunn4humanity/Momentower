using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceObjectScript : MonoBehaviour {

	public float power;

	AudioSource boing;

	void Start()
	{
		boing = GameObject.Find ("boing").GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			boing.Play ();
			Vector2 bouncePos = transform.position;
			Vector2 collisionPos = collider.contacts [0].point;
			Vector2 reflectVec = collisionPos - bouncePos;
			collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (reflectVec.normalized * power, ForceMode2D.Impulse);
		}

	}
}
