using UnityEngine;

public class UpDownMover : MonoBehaviour
{
    readonly float SPEED = 2.5f;

    [SerializeField]
    float topY;
    [SerializeField]
    float botY;

    [SerializeField]
    bool goDownFirst = false;

    void Awake()
    {
        if (goDownFirst)
            goUp = false;
    }

    void Update()
    {
        Move();
    }

    bool goUp = true;
    void Move()
    {
        var pos = transform.localPosition;
        float yDelta = SPEED * Time.deltaTime;

        // Move in the other direction
        if (!goUp)
            yDelta *= -1;

        pos.y += yDelta;
        pos.y = Mathf.Clamp(pos.y, botY, topY);

        transform.localPosition = pos;

        // Reverse direction upon reaching an edge
        if (pos.y == topY || pos.y == botY)
            goUp = !goUp;
    }

    public void ReverseDirection()
    {
        goUp = !goUp;
    }
}
