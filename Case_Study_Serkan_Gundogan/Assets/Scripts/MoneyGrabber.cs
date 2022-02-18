using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGrabber : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject BigMoney;
    public GameObject SmallMoney;
    public GameObject Money;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (hit.collider.CompareTag("Untagged"))
                    {
                        return;
                    }
                    if (hit.collider.CompareTag("BigMoney"))
                    {
                        BigMoney.SetActive(true);
                       
                    }
                    if (hit.collider.CompareTag("Money"))
                    {
                        Money.SetActive(true);

                    }
                    if (hit.collider.CompareTag("LittleMoney"))
                    {
                        SmallMoney.SetActive(true);

                    }

                    selectedObject = hit.collider.gameObject;
                }
            }
            else
            {
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pos);
                selectedObject.transform.position = new Vector3(worldPosition.x, 1f, worldPosition.z);
                selectedObject = null;
                BigMoney.SetActive(false);
                Money.SetActive(false);
                SmallMoney.SetActive(false);
            }
        }

        if (selectedObject != null)
        {
            Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(pos);
            selectedObject.transform.position = new Vector3(worldPosition.x, 2f, worldPosition.z);
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
