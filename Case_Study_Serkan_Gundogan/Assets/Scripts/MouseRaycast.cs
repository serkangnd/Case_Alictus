using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRaycast : MonoBehaviour
{
    //public bool isDragging = false;
    //GameObject selectedObject;
    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.collider.tag == "Ring")
    //            {
    //                selectedObject = hit.collider.gameObject;
    //                isDragging = true;
    //            }
    //        }

    //        if (isDragging)
    //        {
    //            Vector3 pos = mousePos();
    //            selectedObject.transform.position = pos;

    //        }

    //        if (Input.GetMouseButtonUp(0))
    //        {
    //            isDragging = false;
    //        }
    //        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

    //    }
    //}

    //Vector3 mousePos()
    //{
    //    return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    //}

    public GameObject selectedObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null){
                    if (!hit.collider.CompareTag("Ring"))
                    {
                        return;
                    }

                    selectedObject = hit.collider.gameObject;
                }
            }
            else
            {
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pos);
                selectedObject.transform.position = new Vector3(worldPosition.x, 2f, worldPosition.z);
                selectedObject = null;
            }
        }

        if (selectedObject != null )
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pos);
            selectedObject.transform.position = new Vector3(worldPosition.x, 6f, worldPosition.z);
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
            );
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;

    }
}
