using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YunnManager : MonoBehaviour {

	public Image panel;

	void Start () 
	{
		StartCoroutine ("fadein");
	}
	
	IEnumerator fadein()
	{
		while (panel.color.a > 0f) 
		{
			panel.color = new Color (0,0,0, panel.color.a - Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds (2f);

		SceneManager.LoadScene ("ground");
	}

}
