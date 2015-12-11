using UnityEngine;
using System.Collections;

public class ArmMovement : MonoBehaviour {

    float speed = 5.0f;
    KeyCode left = KeyCode.LeftArrow;
    KeyCode right = KeyCode.RightArrow;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(left))
        {
            Move(-0.01f);
            Rotate(-0.01f);
            Grow(-1.8f);
        }
        else if (Input.GetKey(right))
        {
            Move(0.01f);
            Rotate(0.01f);
            Grow(1.8f);
        }
    }

    void Move(float direction)
    {
        transform.position = Vector3.MoveTowards(transform.position,
                                               new Vector3(0.2f * direction, transform.position.y, transform.position.z),
                                               speed * Time.deltaTime);
        
    }
    void Rotate(float delta)
    {
        var rot = transform.rotation;
        rot.z += delta * Time.deltaTime;
        transform.rotation = rot;
        
    }
    void Grow (float Epsilon)
    {
        var lenght = transform.localScale;
        lenght.x += Epsilon * Time.deltaTime;
        transform.localScale = lenght;
    }
}

