using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrailerManager : MonoBehaviour {

    Image panel;
    GameObject title;
    Text talking;
    Image lightman;
    Image fireplace;

    public AudioSource[] ba;
    int countBa = 0;

    const float speed = -300f;

    string[] scripts;

	void Start () 
    {
        panel = GameObject.Find("Panel").GetComponent<Image>();
        title = GameObject.Find("Title");
        talking = GameObject.Find("Talking").GetComponent<Text>();
        lightman = GameObject.Find("Lightman").GetComponent<Image>();
        fireplace = GameObject.Find("Fireplace").GetComponent<Image>();

        scripts = new string[13];
        scripts[0] = "\"여. 반가워.\"";
        scripts[1] = "\"너희 세상은 참 바쁘게 돌아가는 것 같아.\"";
        scripts[2] = "\"누구는 코인으로 대박이 났다더라…\"";
        scripts[3] = "\"누구는 연예인과 결혼했다더라…\"";
        scripts[4] = "\"누구는 사업이 대박났다더라…\"";
        scripts[5] = "\"이런 얘기가 쉴 새 없이 쏟아지더군.\"";
        scripts[6] = "\"그런 세상이라면 분명 지치고 힘들 때가 찾아올거야.\"";
        scripts[7] = "\"지금 너도 그럴 수 있겠지.\"";
        scripts[8] = "\"절대 닿을 수 없을 것 같은 높은 곳을 바라보며 절망을 느낄 수도 있어.\"";
        scripts[9] = "\"그리고 난 높은 곳 저 너머로 바래다 줄 수 있는 힘을 가지고 있지.\"";
        scripts[10] = "\"내가 누구냐고?\"";
        scripts[11] = "\"...그건 우리 세계에 오면 알려줄게.\"";
        scripts[12] = "\"Momentower에서 봐.\"";


        StartCoroutine("playTrailer");	
	}
	
    IEnumerator playTrailer()
    {

        WaitForSeconds sec = new WaitForSeconds(1f);

        while (panel.color.a > 0f) 
        {
            panel.color = new Color (0,0,0, panel.color.a - Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1f);

        while (title.transform.localPosition.x > -640f)
        {
            title.transform.Translate(Time.deltaTime * speed, 0, 0);
            yield return null;
        }
            

        yield return sec;


        for (int i = 0; i < scripts.Length; i++)
        {
            yield return StartCoroutine(texting(scripts[i]));
            yield return sec;
            yield return sec;
        }
            
        talking.text = "";

        for (int i = 0; i < 5; i++)
        {
            lightman.color = new Color(1,1,1, lightman.color.a - 0.2f);
            fireplace.color = new Color(1,1,1, fireplace.color.a - 0.2f);
            yield return new WaitForSeconds(0.4f);
        }

    }

    IEnumerator texting(string text)
    {

        talking.text = "";
        int index = 0;
        WaitForSeconds sec = new WaitForSeconds (0.1f);
        while (talking.text != text) 
        {
            talking.text += text [index];
            if(text[index] != '\"' && text[index] != ' '&& text[index] != '.')
                playBa();
            index++;
            yield return sec;
        }

    }

    void playBa()
    {
        ba[countBa].Play();
        countBa++;
        if (countBa >= 4)
            countBa = 0;
    }
}
