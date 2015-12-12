using UnityEngine;
using System.Collections;

public class ShootBall : MonoBehaviour {

    public Transform positionUp;
    public Transform positionDown;
    public Vector2 direction;
    private readonly float SPEED = 5f;

    private KeyCode up = KeyCode.UpArrow;
    private KeyCode down = KeyCode.DownArrow;

    void Start()
    {
        direction = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(up))
        {
            goUp();
        }
        else if (Input.GetKeyDown(down))
        {
            goDown();
        }

        transform.position = Vector2.MoveTowards(transform.position, direction, SPEED * Time.deltaTime);
    }

    void goUp()
    {
        direction = positionUp.position;
    }

    void goDown()
    {
        direction = positionDown.position;
    }

}
