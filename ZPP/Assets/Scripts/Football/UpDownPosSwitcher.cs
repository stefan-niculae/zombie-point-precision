using UnityEngine;

public class UpDownPosSwitcher : MonoBehaviour
{
    [SerializeField]
    float smallY;
    [SerializeField]
    float bigY;

    float startY;
    float targetY;

    readonly float SCALE_DURATION = .2f; // in seconds

    void Start()
    {
        var scale = transform.localScale;
        targetY = scale.y = bigY;
        transform.localScale = scale;
    }

    float startTime;
    void Update()
    {
        float vert = Input.GetAxis("Vertical");

        float currY = transform.localScale.y;

        // Up
        if (vert > 0 && targetY != smallY)
        {
            startY = currY;
            targetY = smallY;
            startTime = Time.time;
        }

        // Down
        if (vert < 0 && targetY != bigY)
        {
            startY = currY;
            targetY = bigY;
            startTime = Time.time;
        }

        // If we haven't reached the target
        if (transform.localScale.y != targetY)
        {
            float timeDiff = (Time.time - startTime) / SCALE_DURATION;
            timeDiff = Mathf.Clamp01(timeDiff);

            float newY = startY + (targetY - startY) * timeDiff;
            var scale = transform.localScale;
            scale.y = newY;
            transform.localScale = scale;
        }
    }
}
