using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class SaveController : MonoBehaviour
{

    public GameObject savedMomentObject; // is the name the best?
    public GameObject character;
    public Image panel;
    public AudioSource shutter;
    public AudioSource pop;

    public GameObject particle;

    public bool collidingSavePoint = false;

    string folderPath;

    void Start()
    {
        folderPath = Application.dataPath + "/photos";
        DirectoryInfo dir = new DirectoryInfo(folderPath);
        dir.Create();

        if (PlayerPrefs.HasKey("hasSavedMoment") == false)
            PlayerPrefs.SetInt("hasSavedMoment", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            captureMoment();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            returnToMoment();
        }
    }


    void captureMoment()
    {
        if (collidingSavePoint == false)
            return;

        if (character.GetComponent<CharacterController>().jumped == true)
            return;

        if (character.GetComponent<CharacterController>().controlling == false)
            return;

        PlayerPrefs.SetInt("hasSavedMoment", 1);
        StartCoroutine("shutterAnimationAndScreenshot");
        StartCoroutine("fadeOutAnimationOfSavedMomentObject");
        setSavedMomentPos();

    }

    IEnumerator shutterAnimationAndScreenshot()
    {
        shutter.Play();
        panel.color = new Color(0, 0, 0, 1);
        while (panel.color.a > 0f)
        {
            panel.color = new Color(1, 1, 1, panel.color.a - Time.deltaTime * 2);
            yield return null;
        }
        StartCoroutine("screenShot");
    }

    IEnumerator screenShot()
    {

        yield return new WaitForEndOfFrame();
        Texture2D screenTex = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        Rect area = new Rect(0f, 0f, Screen.width, Screen.height);
        screenTex.ReadPixels(area, 0, 0);

        if (Directory.Exists(folderPath) == false)
        {
            Directory.CreateDirectory(folderPath);
        }

        File.WriteAllBytes(folderPath + "/" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-tt") + ".png", screenTex.EncodeToPNG());

        Destroy(screenTex);

    }

    IEnumerator fadeOutAnimationOfSavedMomentObject()
    {
        Image moment = savedMomentObject.GetComponent<Image>();
        moment.color = new Color(1, 1, 1, 0.47f);
        yield return new WaitForSeconds(0.5f);
        while (moment.color.a > 0)
        {
            moment.color = new Color(1, 1, 1, moment.color.a - Time.deltaTime);
            yield return null;
        }
    }

    void setSavedMomentPos()
    {
        savedMomentObject.GetComponent<Image>().sprite = character.GetComponent<Image>().sprite;
        savedMomentObject.SetActive(true);
        savedMomentObject.transform.SetParent(character.transform.parent);
        savedMomentObject.transform.position = character.transform.position;

        PlayerPrefs.SetFloat("savedPositionX", savedMomentObject.transform.position.x);
        PlayerPrefs.SetFloat("savedPositionY", savedMomentObject.transform.position.y);
        PlayerPrefs.SetInt("savedFloor", int.Parse(savedMomentObject.transform.parent.gameObject.name));
    }



    void returnToMoment()
    {
        if (character.GetComponent<CharacterController>().controlling == false)
            return;

        if (PlayerPrefs.GetInt("hasSavedMoment") == 0)
            return;

        pop.Play();
        goToSavedMomentPos();
        StartCoroutine("returnEffect");
        StartCoroutine("fadeOutAnimationOfSavedMomentObject");
    }

    void goToSavedMomentPos()
    {
        savedMomentObject.transform.parent.gameObject.SetActive(true);
        character.transform.SetParent(savedMomentObject.transform.parent);
        character.transform.position = savedMomentObject.transform.position;
    }

    IEnumerator returnEffect()
    {
        particle.SetActive(true);
        particle.GetComponent<ParticleSystem>().startColor = Color.white;
        while (particle.GetComponent<ParticleSystem>().startColor.a > 0)
        {
            particle.GetComponent<ParticleSystem>().startColor = new Color(1, 1, 1, particle.GetComponent<ParticleSystem>().startColor.a - Time.deltaTime);
            yield return null;
        }
        particle.SetActive(false);


    }
        
    public void openGallary()
    {
        if (Directory.Exists(folderPath) == true)
            System.Diagnostics.Process.Start(folderPath);
    }
}
