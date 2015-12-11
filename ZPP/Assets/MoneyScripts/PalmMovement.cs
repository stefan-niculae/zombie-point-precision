using UnityEngine;
using System.Collections;

public class PalmMovement : MonoBehaviour
{

    float speed = 5.0f;
    KeyCode left = KeyCode.LeftArrow;
    KeyCode right = KeyCode.RightArrow;

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
                                               new Vector3(5f * direction, transform.position.y, transform.position.z),
                                               speed * Time.deltaTime);

    }

}