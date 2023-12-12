using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFloorScript : MonoBehaviour {

    float distance = 350;
    public float speed;

    float x;
    float y;

    void Start () 
    {
        x = transform.localPosition.x;
        y = transform.localPosition.y;
    }

    void Update () 
    {
        transform.position -= new Vector3 (0, 1, 0) * Time.deltaTime *speed;

        if (y - distance >= transform.localPosition.y) 
        {
            transform.localPosition = new Vector2(x,y);
        } 
    }
        
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "character")
        {
            transform.GetComponent<BoxCollider2D>().isTrigger = true;
        }

    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "character")
        {
            transform.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
