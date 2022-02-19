using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacummMovement : MonoBehaviour
{
    protected Joystick joystick;

    public float turnSpeed;


    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        Walk();

    }
    void Walk()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(joystick.Horizontal * 5f, GetComponent<Rigidbody>().velocity.y, joystick.Vertical * 5f);

        transform.eulerAngles = new Vector3(0, Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * 180 / Mathf.PI, 0);
    }
}
