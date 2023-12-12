using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class intoTowerScript : MonoBehaviour {

	public GameObject fronttop;
	public GameObject tower;
	public GameObject towerObject;

	public bool right;

	public AudioSource outside;
	public AudioSource inTower;

	public Image panel;
	public GameObject character;

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			if (right) 
			{
				StartCoroutine (rightTrue(collider));
			} 
			else 
			{
				StartCoroutine (rightFalse(collider));
			}

		}
	}

	IEnumerator rightTrue(Collision2D collider)
	{
		outside.Stop ();
		character.GetComponent<CharacterController> ().controlling = false;
		while (panel.color.a < 1f) 
		{
			panel.color = new Color (0,0,0, panel.color.a + Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds (1f);
		fronttop.SetActive (false);
		tower.SetActive (true);
		towerObject.SetActive (true);
		collider.gameObject.transform.SetParent (tower.transform);
		collider.gameObject.transform.localPosition = new Vector2 (-202f, -130f);
		inTower.Play ();
		panel.color = new Color (0,0,0,0);

		character.GetComponent<CharacterController> ().controlling = true;

	}

	IEnumerator rightFalse(Collision2D collider)
	{
		inTower.Stop ();
		character.GetComponent<CharacterController> ().controlling = false;
		while (panel.color.a < 1f) 
		{
			panel.color = new Color (0,0,0, panel.color.a + Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds (1f);
        if(PlayerPrefs.GetInt ("arrivedTop") == 0)
			outside.Play ();
		fronttop.SetActive (true);
		tower.SetActive (false);
		collider.gameObject.transform.SetParent (fronttop.transform);
		collider.gameObject.transform.localPosition = new Vector2 (0f, -121f);
        towerObject.GetComponent<SaveController> ().collidingSavePoint = false;
		panel.color = new Color (0,0,0,0);

		character.GetComponent<CharacterController> ().controlling = true;

	}
}
