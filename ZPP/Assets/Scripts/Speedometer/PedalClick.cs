using UnityEngine;
using System.Collections;

public class PedalClick : MonoBehaviour {

    public Transform maxRotation;
    public Transform minRotation;

    private readonly float ROTATION_SPEED = 100f;
    private readonly float ROTATION_ERROR = 0.01f;

    private KeyCode accelration = KeyCode.Space;

    private bool startGame;

    IEnumerator Start()
    {
        startGame = false;
        yield return new WaitForSeconds(1.5f);
        startGame = true;
    }

    void Update()
    {
        if (Input.GetKey(accelration))
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
        transform.Rotate(new Vector3(0f, 0f, -1f) * ROTATION_SPEED * Time.deltaTime);
    }

    void Decelerate()
    {
        transform.Rotate(new Vector3(0f, 0f, 1f) * ROTATION_SPEED * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: change this to end
        Time.timeScale = 0;
    }
}
