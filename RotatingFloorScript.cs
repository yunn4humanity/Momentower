using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingFloorScript : MonoBehaviour {


    bool colliding = false;

    void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0,0,0);
    }


	// Update is called once per frame
	void Update () 
    {
        if (colliding == false)
        {
            // turn Rot Z to 0. 나중에 구현?
        }
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "character")
        {
            colliding = true;
        }

    }

    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.name == "character")
        {
            colliding = false;
        }
    }
}
