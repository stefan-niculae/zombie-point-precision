using UnityEngine;
using System.Collections;

public class PedalClick : MonoBehaviour {

    private GameObject pin;
    public Transform maxRotation;
    public Transform minRotation;

    private float percentage;
    private readonly float ROTATION_SPEED = 0.1f;

    private KeyCode accelration = KeyCode.Space;

    void Start()
    {
        pin = GameObject.Find("needle");
        percentage = 50;
    }

    void Update()
    {
        if (Input.GetKey(accelration))
        {
            Accelerate();
        }
        else
        {
            Decelerate();
        }
    }

    void Accelerate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, maxRotation.rotation, Time.deltaTime * ROTATION_SPEED);
    }

    void Decelerate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, minRotation.rotation, Time.deltaTime * ROTATION_SPEED);
    }
}
