using UnityEngine;

public class PrecisionWatcher : MonoBehaviour
{
    [SerializeField]
    Collider2D correctZone;

    [SerializeField]
    ShrinkingCenter center;

    [SerializeField]
    ArmContracter contracter;
    [SerializeField]
    UpDownMover mover;

    bool insideCorrectZone = false;

    void OnTriggerEnter2D(Collider2D other)
	{
        if (other == correctZone)
            insideCorrectZone = true;
    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other == correctZone)
            insideCorrectZone = false;
	}

	void Update()
	{
		if (Input.GetButtonDown("Dumbbell"))
		{
            contracter.StartContracting();
            // mover.ReverseDirection();

            if (insideCorrectZone)
                center.Spawn();
			else
                PhaseManager.Instance.EndGame("gantera outside");
        }
	}
}
