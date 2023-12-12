using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCurrentFloorScript : MonoBehaviour
{

    public GameObject mainCamera;
    public GameObject panel;

    public GameObject[] floors;

    GameObject beforeFloor;
    GameObject afterFloor;


    public void setTower()
    {
        for (int i = 1; i < floors.Length; i++)
            floors[i] = GameObject.Find((i + 1).ToString());

        for (int i = 0; i < floors.Length; i++)
            floors[i].SetActive(false);

        floors[1].SetActive(true);
        floors[1].transform.parent.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 1000, Color.blue);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward * 1000f, out hit, 1000f))
        {
            mainCamera.transform.position = new Vector3(0, 1080 * (hit.collider.transform.parent.localPosition.y / 360f), -10f);
            panel.transform.localPosition = hit.collider.transform.parent.localPosition;
            transform.SetParent(hit.collider.transform.parent);

            beforeFloor = hit.transform.gameObject;

            if (afterFloor == null) { }
            else if (afterFloor != beforeFloor)
            {
                updateCurrentFloor(hit.transform.parent.gameObject.name);
            }

            afterFloor = beforeFloor;
        }
    }

    void updateCurrentFloor(string hittedFloorName)
    {

        int hittedFloorIndex = findIndexOf(hittedFloorName);

        for (int j = 0; j < floors.Length; j++)
        {
            if (floors[j] != floors[hittedFloorIndex])
                floors[j].SetActive(false);
        }

        for (int j = -2; j < 3; j++)
        {
            if (hittedFloorIndex + j >= 0 && hittedFloorIndex + j < floors.Length)
                floors[hittedFloorIndex + j].SetActive(true);
        }
    }

    int findIndexOf(string hittedFloorName)
    {
        int index = -1;

        for (int i = 0; i < floors.Length; i++)
        {
            if (floors[i].name == hittedFloorName)
            {
                index = i;
                break;
            }
        }

        return index;
    }
}
