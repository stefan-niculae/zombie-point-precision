using UnityEngine;

public class ArmContracter : MonoBehaviour
{
    const float EPSILON = 5f;

    [SerializeField]
    float detractedRot;
    [SerializeField]
    float contractedRot;

    readonly float CONTRACTING_SPEED = 235f;
    readonly float DETRACTING_SPEED = 50f;

    float rot;

	void Awake()
	{
        rot = contractedRot;
    }

    void Update()
	{
		if (isContracting)
            Contract();
		else
        	Detract();

        rot %= 360;
        // Set rotation
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

	void Detract()
	{
        rot += DETRACTING_SPEED * Time.deltaTime;

        // Can't rotate more than the maximum detracted rotation
        if (rot > detractedRot)
        {
            rot = detractedRot;
        }
    }

    bool isContracting = false;
    public void StartContracting()
	{
        isContracting = true;
    }

	void Contract()
	{
        // Reached fully contracted state
        if (rot <= contractedRot)
		{
            rot = contractedRot;
            isContracting = false;
        }

        rot -= CONTRACTING_SPEED * Time.deltaTime;
    }
}
