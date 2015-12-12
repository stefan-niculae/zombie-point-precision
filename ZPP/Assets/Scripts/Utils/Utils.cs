using UnityEngine;

public class Utils : Singleton<Utils>
{
    const float EPSILON = .01f;

    public bool FloatEqual(float a, float b)
	{
        return Mathf.Abs(a - b) < EPSILON;
    }

	public float RandRangeAtLeast(float min, float max, float current, float atLeast)
	{
        float result;
        do
        {
            result = Random.Range(min, max);
        } while (Mathf.Abs(result - current) < atLeast);

        return result;
    }
}
