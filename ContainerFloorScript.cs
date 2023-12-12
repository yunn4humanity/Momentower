using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


static class Constants
{
    public static float defaultAnimeTime = 40f;
    public static float defaultDirectionValue = 1f;
}

public class ContainerFloorScript : MonoBehaviour {

    const float defaultAnimeTime = 40f;
    const float defaultDirectionValue = 1f;

    public Sprite[] animations;
    public bool right;
    public float speed;
    int index = 0;
    float time = 0;
    float direction = defaultDirectionValue;
    float animeTime;

    void Start()
    {
        if (right)
            direction = defaultDirectionValue;
        else
            direction = defaultDirectionValue * (-1f);
            
        animeTime = defaultAnimeTime / speed;
    }

    // Update is called once per frame
    void Update () 
    {
        time += Time.deltaTime;
        if (time >= animeTime) 
        {
            time = 0;
            this.GetComponent<Image> ().sprite = animations [index];
            index++;

            if (index >= animations.Length)
                index = 0;
        }


    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.name == "character") 
            collider.gameObject.transform.position += new Vector3 (1, 0, 0) * direction * Time.deltaTime * speed;
    }

}
