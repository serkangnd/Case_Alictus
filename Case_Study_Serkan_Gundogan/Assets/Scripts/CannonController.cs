using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;

    public GameObject Cannonball;
    public Transform ShotPoint;

    //mobile testings
    private float _startingPosition;


    private void Update()
    {
        //wasd movement cannon
        float HorizontalRotation = Input.GetAxis("Horizontal");
        float VericalRotation = Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
            new Vector3(0, HorizontalRotation * rotationSpeed, VericalRotation * rotationSpeed));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CannonShot();
        }

        //mobile input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startingPosition = touch.position.x;
                    break;
                case TouchPhase.Moved:
                    if (_startingPosition > touch.position.x)
                    {
                        transform.Rotate(Vector3.back, -rotationSpeed * Time.deltaTime);
                    }
                    else if (_startingPosition < touch.position.x)
                    {
                        transform.Rotate(Vector3.back, rotationSpeed * Time.deltaTime);
                    }
                    break;
                case TouchPhase.Ended:
                    Debug.Log("Touch Phase Ended.");
                    CannonShot();
                    break;
                case TouchPhase.Stationary:
                    _startingPosition = touch.position.x;
                    break;
            }
        }            
    }

    void CannonShot()
    {
        GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
        CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
    }
}
