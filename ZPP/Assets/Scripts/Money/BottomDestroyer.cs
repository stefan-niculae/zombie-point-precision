using UnityEngine;

public class BottomDestroyer : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
    {
		PhaseManager.Instance.EndGame("coin missed");
        Destroy(other.gameObject);
    }
}
