using UnityEngine;

public class ColorBG : MonoBehaviour
{
	readonly static float GROW_DURATION = .5f; // in seconds

	[SerializeField]
    Vector3 shrunkenScale;
	[SerializeField]
    Vector3 grownScale;


    void Awake()
	{
        transform.localScale = shrunkenScale;
    }

	void Update()
	{
		if (isGrowing)
            Grow();
    }

    bool isGrowing = false;
    float growthStart;
    Vector3 growthDelta;
    public void StartGrow()
	{
        growthStart = Time.time;
        growthDelta = grownScale - shrunkenScale;
        isGrowing = true;
    }
	void Grow()
	{
        float timeDiff = (Time.time - growthStart) / GROW_DURATION;
        // Guard floating point imprecisions
        if (timeDiff > 1)
            timeDiff = 1;

        transform.localScale = shrunkenScale + growthDelta * timeDiff;

        if (timeDiff >= 1)
            isGrowing = false;
    }

}
