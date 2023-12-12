using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObjectScript : MonoBehaviour {

    float direction = 1;
    float speed = 20;
    float distance = 10f;
    float y;

    void Start()
    {
        y = this.transform.localPosition.y;
    }

	// Update is called once per frame
	void Update ()
    {
        transform.position += new Vector3(0, 1, 0) * direction * Time.deltaTime * speed;

        if (direction == 1)
        {
            if (y + distance <= transform.localPosition.y)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, y + distance);
                direction *= -1;
            }
        }
        else if (direction == -1)
        {
            if (y >= transform.localPosition.y)
            {
                transform.localPosition = new Vector2(transform.localPosition.x, y);
                direction *= -1;
            }
        }

    }
}
