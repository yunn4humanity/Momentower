using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFlorr : MonoBehaviour
{

    float count;
    public float distance;
    public bool horizental;
    public float speed;

    public float direction = 1;

    float x;
    float y;
    float startDir;

    void Start()
    {
        x = this.transform.localPosition.x;
        y = this.transform.localPosition.y;
        startDir = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if (horizental)
        {
            transform.position += new Vector3(1, 0, 0) * direction * Time.deltaTime * speed;

            if (startDir == 1)
            {
                if (direction == 1)
                {
                    if (x + distance <= transform.localPosition.x)
                    {
                        transform.localPosition = new Vector2(x + distance, transform.localPosition.y);
                        direction *= -1;
                    }
                }
                else if (direction == -1)
                {
                    if (x >= transform.localPosition.x)
                    {
                        transform.localPosition = new Vector2(x, transform.localPosition.y);
                        direction *= -1;
                    }
                }
            }
            else if (startDir == -1)
            {
                if (direction == 1)
                {
                    if (x <= transform.localPosition.x)
                    {
                        transform.localPosition = new Vector2(x, transform.localPosition.y);
                        direction *= -1;
                    }
                }
                else if (direction == -1)
                {
                    if (x - distance >= transform.localPosition.x)
                    {
                        transform.localPosition = new Vector2(x - distance, transform.localPosition.y);
                        direction *= -1;
                    }
                }
            }
        }
        else
        {
            transform.position += new Vector3(0, 1, 0) * direction * Time.deltaTime * speed;

            if (startDir == 1)
            {
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
            else if (startDir == -1)
            {
                if (direction == 1)
                {
                    if (y <= transform.localPosition.y)
                    {
                        transform.localPosition = new Vector2(transform.localPosition.x, y);
                        direction *= -1;
                    }
                }
                else if (direction == -1)
                {
                    if (y - distance >= transform.localPosition.y)
                    {
                        transform.localPosition = new Vector2(transform.localPosition.x, y - distance);
                        direction *= -1;
                    }
                }
            }
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.name == "character")
        {
            if (horizental)
            {
                collider.gameObject.transform.position += new Vector3(1, 0, 0) * direction * Time.deltaTime * speed;
            }
            else
            {
                collider.gameObject.transform.position += new Vector3(0, 1, 0) * direction * Time.deltaTime * speed;
            }
        }
			
    }
}
