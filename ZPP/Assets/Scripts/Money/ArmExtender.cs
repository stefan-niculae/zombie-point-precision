using UnityEngine;

public class ArmExtender : MonoBehaviour
{
	[SerializeField]
	float smallX;
	[SerializeField]
	float bigX;

    readonly float SPEED = 5f;

    void Update()
	{
        float horiz = Input.GetAxis("Horizontal");

        var scale = transform.localScale;
        scale.x += horiz * SPEED * Time.deltaTime;
        scale.x = Mathf.Clamp(scale.x, smallX, bigX);

        transform.localScale = scale;
    }
}
