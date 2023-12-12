using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour {

	public float gravity;

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
            if (hasSameParentWith(collider.gameObject) == false)
                return;

			collider.gameObject.GetComponent<CharacterController> ().onChangingGravity = true;
			collider.gameObject.GetComponent<CharacterController> ().changedGravity = gravity;
		}

	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if (collider.gameObject.name == "character") 
		{
			collider.gameObject.GetComponent<CharacterController> ().onChangingGravity = false;
		}

	}

    bool hasSameParentWith(GameObject character)
    {
        if (character.transform.parent == transform.parent)
            return true;
        else
            return false;
    }
}
