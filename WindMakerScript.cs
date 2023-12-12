using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMakerScript : MonoBehaviour {


    public float windForce;

    // 바람 부는 애니메이션 필요! 뭔가가 흩날려야 함. 바람을 직관적으로 표현할 뭔가가 필요.
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.name == "character") 
        {
            collider.gameObject.transform.position += new Vector3 (1, 0, 0) * Time.deltaTime * windForce;
        }

    }
}
