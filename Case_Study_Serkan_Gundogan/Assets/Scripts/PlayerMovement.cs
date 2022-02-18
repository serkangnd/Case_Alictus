using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected Joystick joystick;
    public Animator animator;
    public float turnSpeed;

    public enum AnimationParameter
    {
        speed,
    }
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

        animator.SetFloat(AnimationParameter.speed.ToString(), Mathf.Abs(joystick.Horizontal));
    }
}
