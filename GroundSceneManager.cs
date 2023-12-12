using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundSceneManager : MonoBehaviour {

	public Image panel;
	public GameObject title;
	public GameObject start;

	bool keydowned = false;

	public GameObject character;
	public GameObject[] rooms;

	public GameObject tower;

	GameObject testplaymanager;

	void Start()
	{
		testplaymanager = GameObject.Find ("TestPlayManager");
		tower.SetActive (false);
       
	}

	void Update()
	{
		if (keydowned == false && Input.anyKeyDown) 
		{
			keydowned = true;
			StartCoroutine ("fadeInAndStartGame");
		}
	}

    IEnumerator fadeInAndStartGame()
	{
		while (panel.color.a < 1f) 
		{
			panel.color = new Color (0,0,0, panel.color.a + Time.deltaTime);
			yield return null;
		}

		yield return new WaitForSeconds (2f);

		title.SetActive(false);
		tower.SetActive (true);

        if (testplaymanager.GetComponent<TestPlayManager>().startInTower == true)
        {
            AudioSource outside = GameObject.Find("BGMOutside").GetComponent<AudioSource>();
            AudioSource inTower = GameObject.Find("BGMTower").GetComponent<AudioSource>();

            outside.Stop();
            inTower.Play();

            character.GetComponent<CheckCurrentFloorScript>().setTower();
            GameObject nthFloorObj = tower.transform.GetChild (testplaymanager.GetComponent<TestPlayManager> ().startFloor).gameObject;
            setActiveTrueNthFloorAndUpDown(nthFloorObj);
            setCharacterPositionAndFloor(new Vector2 (character.transform.position.x, nthFloorObj.transform.position.y), nthFloorObj.transform);
        }
        else
        {
            start.SetActive(true);
            character.GetComponent<CheckCurrentFloorScript>().setTower();
        }

        if (testplaymanager.GetComponent<TestPlayManager>().resetOnBuild == false)
        {
            

            if (PlayerPrefs.HasKey("savedFloor") == true)
            {
                start.SetActive(false);

                AudioSource outside = GameObject.Find("BGMOutside").GetComponent<AudioSource>();
                AudioSource inTower = GameObject.Find("BGMTower").GetComponent<AudioSource>();

                outside.Stop();
                inTower.Play();

                GameObject nthFloorObj =  tower.transform.GetChild (PlayerPrefs.GetInt("savedFloor")).gameObject; 
                setActiveTrueNthFloorAndUpDown(nthFloorObj);
                setCharacterPositionAndFloor(new Vector2 (PlayerPrefs.GetFloat("savedPositionX"), PlayerPrefs.GetFloat("savedPositionY")), nthFloorObj.transform);
            }
        }

		while (panel.color.a > 0f) 
		{
			panel.color = new Color (0,0,0, panel.color.a - Time.deltaTime);
			yield return null;
		}


	}
        
    public void setActiveTrueNthFloorAndUpDown(GameObject nthFloorObj)
    {

        nthFloorObj.SetActive (true);

        int floor = int.Parse(nthFloorObj.name);

        if (floor > 0) 
        {
            GameObject beforeNthFloorObj = tower.transform.GetChild (floor-1).gameObject;
            beforeNthFloorObj.SetActive (true);
        }           

        if (floor < 80) 
        {
            GameObject afterNthFloorObj = tower.transform.GetChild (floor+1).gameObject;
            afterNthFloorObj.SetActive (true);
        }

    }

    public void setCharacterPositionAndFloor(Vector2 pos, Transform floor)
    {
        character.transform.SetParent (floor);
        character.transform.position = pos;
        tower.SetActive (true);
    }


	public void changeRoom(GameObject room, bool left)
	{
		GameObject toward = null;

		for (int i = 0; i < rooms.Length; i++)
			rooms [i].SetActive (true);

		for (int i = 0; i < rooms.Length; i++) 
		{
			if (rooms [i] == room) 
			{
				if (left) {
					toward = rooms [i - 1];
					character.transform.localPosition = new Vector2 (280f, character.transform.localPosition.y);
				} 
				else 
				{
					toward = rooms [i + 1];
					character.transform.localPosition = new Vector2 (-280f, character.transform.localPosition.y);
				}
					
			}
		}
					
		character.transform.SetParent (toward.transform);

		for (int i = 0; i < rooms.Length; i++)
			rooms [i].SetActive (false);

		toward.SetActive (true);

	}
}
