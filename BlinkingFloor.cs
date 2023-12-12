using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingFloor : MonoBehaviour {

	public float blinkingTime;
	public float disappearTime;
	float time = 0f;

	bool started = false;
	public float startTime;

    const float blink = 0.02f;

	void Start()
	{
		if (disappearTime == 0)
			disappearTime = blinkingTime;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (started == false) 
		{
			if (time >= startTime) 
			{
				time = 0;
				started = true;
			}
		}

		if (time >= blinkingTime && this.GetComponent<BoxCollider2D> ().enabled == true) 
		{
			time = 0;

			StartCoroutine (blinking(this.GetComponent<BoxCollider2D> ().enabled));


		}
		else if(time >= disappearTime && this.GetComponent<BoxCollider2D> ().enabled == false)
		{
			time = 0;

			StartCoroutine (blinking(this.GetComponent<BoxCollider2D> ().enabled));


		}

	}

	IEnumerator blinking(bool enabled)
	{
		float time = 0;

		while (time <= 0.5f) 
		{
			time += Time.deltaTime;
			yield return null;

			float blinkingTime = 0;
			if (this.GetComponent<Image> ().color.a >= 1) 
			{
                while (blinkingTime <= blink) 
				{
					blinkingTime += Time.deltaTime;
					yield return null;
				}
					
				
				this.GetComponent<Image> ().color = new Color (1,1,1,0);
			}
			else if(this.GetComponent<Image> ().color.a <= 0)
			{
                while (blinkingTime <= blink) 
				{
					blinkingTime += Time.deltaTime;
					yield return null;
				}

				this.GetComponent<Image> ().color = new Color (1,1,1,1);
			}
		}
			
		if (enabled == false) 
		{
			this.GetComponent<BoxCollider2D> ().enabled = true;
			this.GetComponent<Image> ().color = new Color (1,1,1,1);
		}
		else if(enabled == true)
		{
			this.GetComponent<BoxCollider2D> ().enabled = false;
			this.GetComponent<Image> ().color = new Color (1,1,1,0);
		}
	}
}
