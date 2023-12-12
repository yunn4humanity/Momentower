using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightmanTalkScript : MonoBehaviour {

	public Text talk;

	public GameObject savescript;

	public AudioSource BGM;
	public AudioClip finalBGM;

	GameObject tower;

    bool isTalkingEnd;

	void Start()
	{
		if (PlayerPrefs.HasKey ("arrivedTop") == false) 
		{
			PlayerPrefs.SetInt ("arrivedTop", 0);
		}

		tower = GameObject.Find ("tower");
	}

	void OnTriggerEnter2D(Collider2D collider)
	{


		if (collider.name == "character") 
		{
			if (PlayerPrefs.GetInt ("arrivedTop") == 0) // 처음 만날 때
			{
                StartCoroutine ("tutoTalking");
			} 
			else if (PlayerPrefs.GetInt ("arrivedTop") == 1) // 정상 찍고 내려왔을 때
			{
                StartCoroutine ("endingTalking");
			}
		}
	}

	IEnumerator tutoTalking()
	{
		GameObject charactercontroller = GameObject.Find ("character");

		charactercontroller.GetComponent<CharacterController> ().controlling = false;
		charactercontroller.GetComponent<CharacterController> ().stopCharacter ();

        WaitForSeconds sec = new WaitForSeconds(2f);

        yield return StartCoroutine (texting("\"반가워. 고민이 있는 표정이네.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"그런 너를 위해 준비된 게 있지.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"내 뒤로 가면 탑이 있어.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"이 세계의 모두가 그 탑을 오르고 있지.\""));
        yield return sec;
            
        yield return StartCoroutine (texting("\"탑의 꼭대기엔 이 세상의 모든 것이 있다고 하더라고.\n우린 그걸 모멘텀이라 부르기로 했어.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"모든 것의 근본이자 모든 것의 끝…\n그것만 있으면 원하는 건 무엇이든 얻을 수 있지.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"그걸 얻기 위해 모든 사람들은 이 탑을 오르기 시작했고,\n탑을 모멘타워라 부르기 시작했어.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"위로 올라간 사람들 중 아무도 내려오지 않은 걸 보면,\n아직 성공한 사람은 없는 같아.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"너도 뭔가 고민이 있다면, 탑의 꼭대기를 노려보도록 해.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"결국은 네가 원하는 걸 찾게 될테니까.\""));
        yield return sec;

        yield return StartCoroutine (texting("당신은 라이트맨의 말대로 탑으로 향했습니다.\n이 세상의 모든 것을 얻기 위해."));

		charactercontroller.GetComponent<CharacterController> ().controlling = true;
		this.gameObject.SetActive (false);
	}

	IEnumerator endingTalking()
	{
		GameObject charactercontroller = GameObject.Find ("character");
		charactercontroller.GetComponent<CharacterController> ().controlling = false;
		charactercontroller.GetComponent<CharacterController> ().stopCharacter ();

        WaitForSeconds sec = new WaitForSeconds(2f);

        yield return StartCoroutine (texting("\"꼭대기를 보고 왔다고? 정말 대단한걸.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"그 곳을 보고도 여기까지 내려온 건 네가 처음이야.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"그래... 모멘텀은 없고 더 높은 탑들만이 널 반기고 있었겠지.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"엄청난 허무감이 널 덮쳤을거야.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"하지만 그 허무감을 느낀 너이기에,\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"비로소 네가 원하는 걸 얻을 수 있게 된거야.\""));
        yield return sec;

		BGM.clip = finalBGM;
		BGM.Play ();

        yield return StartCoroutine (texting("\"너는 꼭대기에 오르기 위해 수많은 노력을 했을거야.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"계속 떨어지고, 오르고를 반복했겠지.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"그 순간을 저장하기도 했을거야.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"단순히 너의 편의를 위해서 말이지.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"하지만 저장한 그 순간을 떠올려봐.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"긴장감, 몰입, 실패, 성공, 기쁨.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"네가 오른 탑보다 더 높은 탑은 이 세상에 수두룩해.\n그 중 제일 높은 탑엔 모멘텀이 있을지도 모르겠지.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"하지만 그 시각에, 그 탑을 오르면서, 네가 느꼈던 감정은 그 누구도 복사할 수 없어.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"다시 말해 네가 그 시각에, 그 탑을 오르면서, 느꼈던 그 감정은 유일하지.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"그런 유일함을 쌓아온 너는 이미 그 자체로 모든 걸 얻은 것과 같아.\""));
        yield return sec;

        yield return StartCoroutine (texting("\"네가 어떤 순간을 만나든, 이 말을 꼭 기억해줘.\""));
        yield return sec;

        yield return StartCoroutine (texting ("\"네가 만나는 모든 순간은 유일한 가치를 지니고,\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"그 유일함을 쌓아온 너는 이미 그 자체로 완성되어있다는걸.\""));
        yield return sec;

        yield return StartCoroutine (texting ("\"그럼 난 마지막으로 하나를 보여주고 퇴장할게.\""));
        yield return sec;
        yield return StartCoroutine (texting ("\"내 말이 기억이 안 나는 때가 온다면, 언제든 다시 여기로 돌아와.\""));
        yield return sec;

        yield return StartCoroutine (texting ("\"그럼 안녕.\""));
        yield return sec;

		// 게임 초기화. 다시 동화를 처음부터 감상할 수 있게.
		GameObject testplaymanager = GameObject.Find("TestPlayManager");
		testplaymanager.GetComponent<TestPlayManager> ().resetAllSwch ();

		// 플레이어가 찍은 사진 보여주고 게임 종료
		savescript.GetComponent<SaveController> ().openGallary ();
		Application.Quit ();


	
	}

	IEnumerator texting(string text)
	{

        isTalkingEnd = false;

		talk.text = "";
		int index = 0;
		WaitForSeconds sec = new WaitForSeconds (0.05f);
		while (talk.text != text) 
		{
			talk.text += text [index];
			index++;
			yield return sec;
		}

        isTalkingEnd = true;
	}

}
