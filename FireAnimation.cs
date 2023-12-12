using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireAnimation : MonoBehaviour {

	public Sprite[] fires;
	int index = 0;
	float time = 0;

	// Update is called once per frame
	void Update () 
	{
		time += Time.deltaTime;
		if (time >= 0.2f) 
		{
			time = 0;
			this.GetComponent<Image> ().sprite = fires [index];
			index++;

			if (index >= fires.Length)
				index = 0;
		}
	}
}
