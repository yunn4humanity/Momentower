using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayManager : MonoBehaviour {

/* 
   테스트를 위한 편의 기능 구현 코드.
	ex) 빌드할 때마다 초기화하기
	ex) 원하는 지점에서 시작하기
	ex) 원하는 오브젝트 켜고/끄고 시작하기
*/	

	public bool resetOnBuild; // 이건 원래 빌드 전에 이거만 하면 다 리셋하는 스위치.
    public bool resetSwch;
	public GameObject[] npcs;

	public bool startInTower;
	public int startFloor;
  
	void Start()
	{
        if (resetOnBuild == true)
        {
            startInTower = false;
            resetSwch = true;
        }

        if (resetSwch == true)
            resetAllSwch();
			
	}

	public void resetAllSwch()
	{
        PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt ("arrivedTop", 0);
        PlayerPrefs.SetInt ("hasSavedMoment", 0);

		for (int i = 0; i < npcs.Length; i++) 
		{
			PlayerPrefs.SetInt (npcs[i].gameObject.name, 0);
		}
	}


}
