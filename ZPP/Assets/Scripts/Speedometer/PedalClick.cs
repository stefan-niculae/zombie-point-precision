using UnityEngine;
using System.Collections;

public class PedalClick : MonoBehaviour {

    public Transform maxRotation;
    public Transform minRotation;

    private readonly float ROTATION_SPEED = 100f;

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
            Accelerate();
        }
        else
        {
            if (startGame)
            {
                Decelerate();
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
}
