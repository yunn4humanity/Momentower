using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterFloor : MonoBehaviour {

	public float distance;
	public float speed;
	public float direction;

	float x;
	float y;

	// Use this for initialization
	void Start () 
	{
		x = transform.localPosition.x;
		y = transform.localPosition.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += new Vector3 (1, 0, 0) * direction * Time.deltaTime *speed;

		if (direction == 1 && x + distance <= transform.localPosition.x) 
		{
			transform.localPosition = new Vector2(x,y);
		} 
		else if (direction == -1 && x - distance >= transform.localPosition.x) 
		{
			transform.localPosition = new Vector2(x,y);
		}
	}

	void OnCollisionStay2D(Collision2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			collider.gameObject.transform.position += new Vector3 (1, 0, 0) * direction * Time.deltaTime * speed;
		}
	}
}
