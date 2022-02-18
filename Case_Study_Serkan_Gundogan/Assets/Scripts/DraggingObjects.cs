using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingObjects : MonoBehaviour
{
    private float dist;
    private bool dragging = false;
    private Vector3 offSet;
    private Transform toDrag;

    //public enum TagParameter
    //{
    //    Ring,
    //}

    private void Update()
    {
        Vector3 vector3;

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Ring")
                {
                    toDrag = hit.transform;
                    dist = hit.transform.position.z - Camera.main.transform.position.z;
                    vector3 = new Vector3(pos.x, pos.y, dist);
                    vector3 = Camera.main.ScreenToWorldPoint(vector3);
                    offSet = toDrag.position - vector3;
                    dragging = true;
                }
            }
        }

        if (dragging && touch.phase == TouchPhase.Moved)
        {
            vector3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            vector3 = Camera.main.ScreenToWorldPoint(vector3);
            toDrag.position = vector3 + offSet;
        }

        //just in case for cancelling
        if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            dragging = false;
        }

        // testing for pc on other script
    }
}
