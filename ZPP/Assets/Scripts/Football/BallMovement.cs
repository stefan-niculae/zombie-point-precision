using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    private Vector2 direction;
    private readonly float BALL_SPEED = 15f;
    private int randomPos;

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime * BALL_SPEED);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "right foot")
        {
            Debug.Log("HIT");
        }
    }
}
