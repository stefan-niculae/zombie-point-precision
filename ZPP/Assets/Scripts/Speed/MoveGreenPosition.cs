using UnityEngine;
using System.Collections;

public class MoveGreenPosition : MonoBehaviour {

    private float randomRotation;
    private readonly float ROTATION_SPEED = 200f;
    private readonly float ROTATION_ERROR = 0.03f;

    public Transform minRotation;
    public Transform maxRotation;
    // float minRotationDiff;
    const float MIN_ROT_DIFF_PER = .35f;

    void Awake()
    {
        // minRotationDiff = Mathf.Abs(maxRotation.rotation.z - minRotation.rotation.z) * MIN_ROT_DIFF_PER;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1.5f);
        transform.rotation = Quaternion.identity;
        StartCoroutine(ResetPosition());
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(2f);
        GetRandom();
        StartCoroutine(ResetPosition());
    }

    void Update()
    {
        //if they are different
        if(transform.rotation.z - randomRotation > ROTATION_ERROR)
        {
            transform.Rotate(new Vector3(0f, 0f, -0.1f) * Time.deltaTime * ROTATION_SPEED);
        }
        else if(transform.rotation.z + randomRotation < ROTATION_ERROR)
        {
            transform.Rotate(new Vector3(0f, 0f, 0.1f) * Time.deltaTime * ROTATION_SPEED);
        }
    }

    void GetRandom()
    {
        randomRotation = Random.Range(minRotation.rotation.z, maxRotation.rotation.z);
        // randomRotation = Utils.Instance.RandRangeAtLeast(minRotation.rotation.z, maxRotation.rotation.z, transform.rotation.z, minRotationDiff);
    }
}
