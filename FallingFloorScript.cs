using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloorScript : MonoBehaviour {

    // are these names the best?
    public float stayingTime = 2f;
    const float fallingTime = 4f;
    const float fallingFloorGravityScale = 100f; 
    float originPosY;

    float time = 0;

   

    void Start()
    {
        originPosY = transform.localPosition.y;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "character" && collider.gameObject.GetComponent<CharacterController>().jumped == false) 
        {
            StartCoroutine("fallWhenTimerEnds");
        }
    }

    IEnumerator fallWhenTimerEnds()
    {
        float remainingTime = 0f;
        float shakePower = 5f;
        Vector2 originPos = transform.position;

        while (remainingTime <= stayingTime)
        {
            remainingTime += 0.05f;
            transform.position = originPos + new Vector2(Random.Range(-1f,1f),0f) * shakePower * remainingTime;
            yield return null;
        }
        transform.position = originPos;

        GetComponent<Rigidbody2D>().gravityScale = fallingFloorGravityScale;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.tag = "Untagged";
        gameObject.layer = 1;

    }

    void Update()
    {
        if (GetComponent<Rigidbody2D>().gravityScale == fallingFloorGravityScale)
        {
            time += Time.deltaTime;
            if (time >= fallingTime)
            {
                time = 0;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                transform.localPosition = new Vector2(transform.localPosition.x, originPosY);
                GetComponent<BoxCollider2D>().isTrigger = false;
                gameObject.tag = "floor";
                gameObject.layer = 8;
            }
        }
    }
}
