using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjects : MonoBehaviour
{
    public GameObject cubes;
    private Vector3 screenPoint, offset;
    private float lockedYPos;

    void Update()
    {
        if (cubes.transform.position.x > 2.5)
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(2.5f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 15f);
        else if (cubes.transform.position.x <-10f)
            cubes.transform.position = Vector3.MoveTowards(cubes.transform.position, new Vector3(-10f, cubes.transform.position.y, cubes.transform.position.z), Time.deltaTime * 15f);
    }

    void OnMouseDown()
    {
        lockedYPos = screenPoint.x;
        offset = cubes.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = lockedYPos;
        cubes.transform.position = curPosition;
    }
}