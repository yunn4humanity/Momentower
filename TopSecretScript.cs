using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopSecretScript : MonoBehaviour {

	public Text talkingBox;

	public Text[] messages;
	public GameObject[] charText;

	public GameObject lightmanTalking;

	public AudioSource BGM;
	public AudioClip wind;

	GameObject mainCamera;

	GameObject tower;

	public GameObject[] npcs;
    public Sprite[] npcSpritesAfterTop;

	void Start()
	{
		mainCamera = GameObject.Find("Main Camera");
		if (PlayerPrefs.GetInt ("arrivedTop") == 1) // 시작했는데 정상을 찍어둔 경우
		{
			changeMessages ();
            talkingBox.text = "당신은 라이트맨에게로 향합니다.";
		}
		tower = GameObject.Find ("tower");
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == "character") 
		{
			if (PlayerPrefs.GetInt ("arrivedTop") == 0) // 최초로 정상 찍은 경우
			{
				
				PlayerPrefs.SetInt ("arrivedTop", 1);
				changeMessages ();

                StartCoroutine ("topTalking");
			}
		}
	}
        
	void changeMessages()
	{

		BGM.Stop ();

		// 71~80
        messages [0].text = "거센 바람이 야속하기만 합니다.";
        messages [1].text = "그동안 쌓아온 실력, 운, 타이밍. 다 의미가 없습니다.";
        messages [2].text = "크게 떨어질 수 있어서 오히려 좋습니다. 빨리 내려갈 수 있군요.";
        messages [3].text = "뚫린 벽은 더 빨리 내려가도록 도와줄 뿐입니다.";
        charText [0].GetComponent<NpcTalkScript>().idleSaying = "\"로켓 정비가 시간이 조금 걸리네요.\"";

        // 61~70
        messages [4].text = "떨어질 땐 오히려 가짜 발판을 찾아야 합니다.";
        messages [5].text = "떨어질 때도 운이 필요하다니, 조금 웃깁니다.";
        messages [6].text = "올라올 땐 그렇게 간절한 타이밍이, 내려올 땐 아무런 의미도 없습니다.";
        messages [7].text = "오히려 발판이 빨리 떨어졌으면 합니다. 내려가는 것도 힘들군요.";
        charText [1].GetComponent<NpcTalkScript>().idleSaying = "\"점프는 언제나 즐거워~\"";

        // 51~60
        messages [8].text = "좁아진 발판은 오히려 떨어지기 쉽습니다.";
        messages [9].text = "타이밍 좋게 떨어져야 한다니, 이것도 웃깁니다.";
        messages [10].text = "내려가는 데에도 변화하는 중력은 성가십니다.";
        messages [11].text = "무엇을 위해 자연법칙마저 변했던 걸까요.";
        charText [2].GetComponent<NpcTalkScript>().idleSaying = "\"더 많은 노력이 필요해...\"";

        // 41~50
        messages [12].text = "얼음에서 더 미끄러져서 빨리 떨어졌으면 합니다.";
        messages [13].text = "떨어지기 어렵게 발판이 더 길어지네요.";
        messages [14].text = "적게 내리는 눈은 떨어지기에 더 편합니다.";
        messages [15].text = "눈이 더 많이 내리니 떨어지기 불편합니다.";
        charText [3].GetComponent<NpcTalkScript>().idleSaying = "\"잉? 왜 내려가고 있어?\"";

        // 31~40
        messages [16].text = "회전하는 발판은 오히려 떨어지기 좋습니다.";
        messages [17].text = "더 떨어지기 좋게 가만히 있어주네요.";
        messages [18].text = "요리조리 피해서 떨어져야 합니다.";
        messages [19].text = "자동으로 움직이는 건 떨어질 땐 아무런 소용이 없네요.";
        charText [4].GetComponent<NpcTalkScript>().idleSaying = "\"조금 지치는 걸요...\"";

        // 21~30
        messages [20].text = "벽을 탈 필요가 없으니 내려가는 건 아주 빠르군요.";
        messages [21].text = "올라갈 땐 벽을 타야하지만, 내려갈 때 벽은 아무런 쓸모가 없습니다.";
        messages [22].text = "움직이는 저 발판들은 떨어지기 귀찮게 하는 군요.";
        messages [23].text = "가만히 있으니 조금은 나은 것 같습니다.";
        charText [5].GetComponent<NpcTalkScript>().idleSaying = "\"내 말에 토를 다는 겐가?\"";

        // 11~20
        messages [24].text = "한 방향으로 움직이는 발판은 지루합니다. 내려가는 걸 계속 방해하네요.";
        messages [25].text = "발판이 더 길어져서 더욱 방해됩니다. 지겹군요.";
        messages [26].text = "거의 다 내려온 듯 합니다. 빨리 내려가야겠군요.";
        messages [27].text = "변화의 시작이었던 곳이 지금은 아무런 의미도 없네요.";
        charText [6].GetComponent<NpcTalkScript>().idleSaying = "\"뭐야, 내려가는 길이야?\"";
       
        // 01~10
        messages [28].text = "멀어진 거리는 그만큼 떨어지기 쉽게 합니다.";
        messages [29].text = "역시나 거리가 멀어서 떨어지기에 좋군요.";
        messages [30].text = "정말 거의 다 왔습니다.";
        messages [31].text = "드디어 맨 아래에 도착했습니다.\n당신의 굳은 결심이 만들어낸 힘도 이젠 무의미합니다.";
        charText [7].GetComponent<NpcTalkScript>().idleSaying = "\"헥...헥... 힘들어...\"";

		messages [32].text = "라이트맨에게 가서 의미를 물어봅니다.\n모든 걸 알고 있었느냐고.";

		messages [33].text = "진실을 밝혀낼 시간입니다.";

		lightmanTalking.SetActive (true);
	}

    IEnumerator topTalking()
	{
		GameObject charactercontroller = GameObject.Find ("character");
		charactercontroller.GetComponent<CharacterController> ().controlling = false;
        charactercontroller.GetComponent<CheckCurrentFloorScript> ().enabled = false;
		charactercontroller.GetComponent<CharacterController> ().stopCharacter ();

		BGM.clip = wind;
		BGM.Play ();

        yield return StartCoroutine("cameraSlidingAnimation");

        WaitForSeconds sec = new WaitForSeconds(2f);

		yield return StartCoroutine (texting("수많은 인고와 노력 끝에\n모두가 바라던 꼭대기에 도착했습니다."));
        yield return sec;
        yield return StartCoroutine (texting ("그러나 당신을 반기는 건\n당신의 탑보다 더 높은 탑들 뿐이었습니다."));
        yield return sec;

        yield return StartCoroutine (texting("당신은 그제서야 탑을 오른 이들이\n다시 내려오지 않은 이유를 깨달았습니다."));
        yield return sec;
        yield return StartCoroutine (texting ("자신이 허무를 쫓았다는 걸 인정하기 싫었던 것입니다."));
        yield return sec;

        yield return StartCoroutine (texting("그들은 더 높은 탑에 있을지도 모르는 모멘텀을 찾아 날아갔거나,"));
        yield return sec;
        yield return StartCoroutine (texting ("아래로 떨어져 또다른 허무로 도망쳤을 것입니다."));
        yield return sec;

        yield return StartCoroutine (texting("당신은 라이트맨에게 심한 배신감을 느낍니다."));
        yield return sec;
        yield return StartCoroutine (texting ("당신은 라이트맨에게로 향합니다."));

		charactercontroller.GetComponent<CheckCurrentFloorScript> ().enabled = true;
		charactercontroller.GetComponent<CharacterController> ().controlling = true;

		for (int i = 0; i < npcs.Length; i++) 
		{
			PlayerPrefs.SetInt (npcs[i].gameObject.name, 0);
            npcs[i].GetComponent<Image>().sprite = npcSpritesAfterTop[i];
            npcs[i].GetComponent<Image>().SetNativeSize();
		}

		this.gameObject.SetActive (false);
	}

    IEnumerator cameraSlidingAnimation()
    {
        yield return new WaitForSeconds (2f);

        float time = 0;
        while (time <= 3f) 
        {
            time += Time.deltaTime;
            mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, mainCamera.transform.position.y + 4f,mainCamera.transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds (2f);

        time = 0;
        while (time <= 3f) 
        {
            time += Time.deltaTime;
            mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, mainCamera.transform.position.y - 4f,mainCamera.transform.position.z);
            yield return null;
        }

        yield return new WaitForSeconds (2f);
    }

	IEnumerator texting(string text)
	{
        talkingBox.text = "";
		int index = 0;
		WaitForSeconds sec = new WaitForSeconds (0.05f);
        while (talkingBox.text != text) 
		{
            talkingBox.text += text [index];
			index++;
			yield return sec;
		}


	}
}
