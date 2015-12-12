using UnityEngine;
using System.Collections;

public class PalmMovement : MonoBehaviour
{

    private readonly float MOVEMENT_SPEED = 5.0f;
    private readonly float ROTATION_ERROR = 0.01f;
    private readonly float ROTATION_SPEED = 300f;

    KeyCode left = KeyCode.LeftArrow;
    KeyCode right = KeyCode.RightArrow;

    public GameObject handBottom;
    public GameObject handTop;

    // Use this for initialization
    void Start()
    {
        //transform.position = new Vector2(0, -3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left))
        {
            Move(-1);
        }
        else if (Input.GetKey(right))
        {
            Move(1);
        }
    }

    void Move(int direction)
    {

        transform.position = Vector3.MoveTowards(transform.position,
                                               new Vector3(2f * direction, transform.position.y, transform.position.z),
                                               MOVEMENT_SPEED * Time.deltaTime);

        handBottom.transform.localScale -= new Vector3(direction  * -0.02f, 0f, 0f);
        handTop.transform.Rotate(new Vector3(0f, 0f, direction * 0.1f) * Time.deltaTime * ROTATION_SPEED);

    }

}