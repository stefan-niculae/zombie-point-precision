using UnityEngine;

public class BallMovement : MonoBehaviour
{

    readonly float FADE_SPEED = .075f;

    private bool isHit = false;

    Vector2 direction;
    Vector2 bounceDirection;

    readonly Vector2 LEFT_DIR = new Vector2(-3.5f, 0);
    readonly Vector2 UP_BOUNCE_DIR = new Vector2(15f, 7.5f);
    readonly Vector2 DOWN_BOUNCE_DIR = new Vector2(15f, -7.5f);


    public void SetBounceDir (int directionCode)
    {
        // The ball goes left initially no mather which way it bounces
        direction = LEFT_DIR;

        // TODO check why this is random!
        if (directionCode == 0)
            bounceDirection = UP_BOUNCE_DIR;
        if (directionCode == 1)
            bounceDirection = DOWN_BOUNCE_DIR;
    }

    void Update()
    {
        transform.position += (Vector3)direction * Time.deltaTime;

        if (transform.position.x <= 0)
        {
            PhaseManager.Instance.EndGame("football");
            Destroy(gameObject);
        }

        if (isHit)
        {
            GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, FADE_SPEED);

            if (GetComponent<SpriteRenderer>().color.a <= 0)
                Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider == References.Instance.footColl)
        {
            isHit = true;
            direction = bounceDirection;
        }
    }

}
