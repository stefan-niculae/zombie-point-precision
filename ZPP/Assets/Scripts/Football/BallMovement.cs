using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    private readonly float BALL_SPEED = 15f;
    private readonly float BACKDISTANCE = 1f;

    private int randomPos;
    private bool isHit;
    private Vector2 direction;
    private Vector2 upDirection = new Vector2(7f, 7f);
    private Vector2 downDirection = new Vector2(7f, -7f);

    private GameObject foot;

    void Start()
    {
        foot = GameObject.Find("Foot");
        isHit = false;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, direction, Time.deltaTime * BALL_SPEED);

        if (isHit)
        {
            GetComponent<SpriteRenderer>().color -= new Color(0f,0f,0f,0.02f);
        }

        if(GetComponent<SpriteRenderer>().color.a <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.name == "right foot")
        {
            isHit = true;
            foot.GetComponent<ShootBall>().setHit(false);

            if (direction.y >= 0)
            {
                direction = upDirection;
            }
            else
            {
                direction = downDirection;
            }

        }
    }

}
