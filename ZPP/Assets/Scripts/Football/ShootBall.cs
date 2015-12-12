using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour {

    private readonly float ROTATION_SPEED = 800f;
    private readonly float MOVE_SPEED = 15f;
    private readonly float ROTATION_ERROR = 0.01f;
    private bool isHitting;

    private Vector2 upPosition = new Vector2(-5f, 2f);
    private Vector2 downPosition = new Vector2(-5f, -0.5f);
    private Vector2 movingTowards;

    private KeyCode up = KeyCode.UpArrow;
    private KeyCode down = KeyCode.DownArrow;

    public Transform defaultRotation, startRotation, endRotation;

    void Start()
    {
        movingTowards = startRotation.position;
        isHitting = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            HitUP();
        }
        else if (Input.GetKeyDown(down))
        {
            HitDown();
        }

        transform.position = Vector2.MoveTowards(transform.position, movingTowards, Time.deltaTime * MOVE_SPEED);

        if(transform.rotation.z - startRotation.rotation.z > ROTATION_ERROR && isHitting)
        {
            transform.Rotate(new Vector3(0f, 0f, -0.1f) * Time.deltaTime * ROTATION_SPEED);
        }
        else if(transform.rotation.z - endRotation.rotation.z < ROTATION_ERROR && !isHitting)
        {
            transform.Rotate(new Vector3(0f, 0f, 0.1f) * Time.deltaTime * ROTATION_SPEED);
        }

    }

    void HitUP()
    {
        movingTowards = upPosition;
        isHitting = true;
    }

    void HitDown()
    {
        movingTowards = downPosition;
        isHitting = true;
    }

    public void setHit(bool isHitting)
    {
        this.isHitting = isHitting;
    }

}
