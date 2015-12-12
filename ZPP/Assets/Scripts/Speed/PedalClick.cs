using UnityEngine;
using System.Collections;

public class PedalClick : MonoBehaviour
{

    public Transform maxRotation;
    public Transform minRotation;
    public Transform pedalDown, pedalUp, pedal;
    public Transform footDown, footUp, foot;

    private readonly float ACCELERATION_SPEED = 80f;
    private readonly float DECELERATION_SPEED = 50f;
    private readonly float ROTATION_ERROR = 0.01f;

    private bool startGame;

    // void Awake()
    // {
    //     pedal.rotation = pedalUp.rotation;
    // }

    IEnumerator Start()
    {
        startGame = false;
        yield return new WaitForSeconds(1.5f);
        startGame = true;
    }

    void Update()
    {
        if (Input.GetButton("Pedal"))
        {
            if (transform.rotation.z + ROTATION_ERROR > maxRotation.rotation.z)
            {
                Accelerate();
            }
        }
        else
        {
            if (startGame)
            {
                if (transform.rotation.z - ROTATION_ERROR < minRotation.rotation.z)
                {
                    Decelerate();
                }
            }
        }
    }

    void Accelerate()
    {
        transform.Rotate(new Vector3(0f, 0f, -1f) * ACCELERATION_SPEED * Time.deltaTime);
        if (foot.rotation.z - footDown.rotation.z > ROTATION_ERROR)
        {
            foot.Rotate(new Vector3(0f, 0f, 0.1f) * ACCELERATION_SPEED * Time.deltaTime);
            pedal.Rotate(new Vector3(-0.1f, 0f, 0f) * ACCELERATION_SPEED * Time.deltaTime);
        }
    }

    void Decelerate()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * DECELERATION_SPEED * Time.deltaTime);
        if (footUp.rotation.z - foot.rotation.z > ROTATION_ERROR)
        {
            foot.Rotate(new Vector3(0f, 0f, -0.1f) * ACCELERATION_SPEED * Time.deltaTime);
            pedal.Rotate(new Vector3(0.1f, 0f, 0f) * ACCELERATION_SPEED * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PhaseManager.Instance.EndGame("speed");
    }
}