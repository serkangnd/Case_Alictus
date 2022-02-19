using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunRay : MonoBehaviour
{
    [SerializeField] Transform gunAim;
    [SerializeField] LineRenderer lineRend;
    Ray ray;
    RaycastHit hit;
    Camera cam;

    
    //transform gun
    public Transform waterGun;
    public float rotationSpeed;
    float horizontalRotation;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        RotateWaterGun();
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            lineRend.enabled = true;
            lineRend.SetPosition(0, gunAim.transform.position);         
            lineRend.SetPosition(1, hit.point);
           
            if (hit.collider.CompareTag("Trash"))
            {
                hit.collider.GetComponent<WaterHealth>().DealDamage(5);
            }
        }
    }

    void RotateWaterGun()
    {
        horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, horizontalRotation);
    }
}
