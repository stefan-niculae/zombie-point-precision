using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour {

    private readonly float ROTATION_SPEED = 0.01f;
    private readonly float MOVE_SPEED = 15f;
    private Vector2 upPosition = new Vector2(-5f, 2f);
    private Vector2 downPosition = new Vector2(-5f, -0.5f);
    private Vector2 movingTowards;

    private KeyCode up = KeyCode.UpArrow;
    private KeyCode down = KeyCode.DownArrow;

    void Start()
    {
        movingTowards = transform.position;
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

    }

    void HitUP()
    {
        movingTowards = upPosition;
    }

    void HitDown()
    {
        movingTowards = downPosition;
    }

}
