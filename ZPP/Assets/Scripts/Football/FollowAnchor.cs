using UnityEngine;

public class FollowAnchor : MonoBehaviour
{
    [SerializeField]
    Transform anchor;

	void Update()
	{
        transform.position = anchor.position;
    }
}
