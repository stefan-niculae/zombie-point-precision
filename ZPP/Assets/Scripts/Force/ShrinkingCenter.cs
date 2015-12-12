using UnityEngine;

public class ShrinkingCenter : MonoBehaviour
{
    readonly float SHRINK_DURATION = 6; // in seconds
    readonly float RESPAWN_DISTANCE_PER = .4f; // do not set over 50%!

    [SerializeField]
    float topY;
    [SerializeField]
    float botY;

    [SerializeField]
    float initialSizeY;

    float minimumRespawnDistance;

    void Awake()
	{
        minimumRespawnDistance = Mathf.Abs(topY - botY) * RESPAWN_DISTANCE_PER;
        Spawn(firstSpawn: true);
    }

	void Update()
	{
        Shrink();
    }

    float spawnTime;
    float spawnY;
    public void Spawn(bool firstSpawn = false)
	{
        var scale = transform.localScale;
        scale.y = initialSizeY;
        transform.localScale = scale;

        var pos = transform.localPosition;
        // Regenerate until we get one as far away as possible
        if (firstSpawn)
        {
            pos.y = Random.Range(botY, topY);
            firstSpawn = false;
        }
        else
            do
            {
                pos.y = Random.Range(botY, topY);
            } while (Mathf.Abs(pos.y - transform.localPosition.y) < minimumRespawnDistance);
        transform.localPosition = pos;

        spawnY = transform.localScale.y;
        spawnTime = Time.time;
    }

    void Shrink()
    {
        float timeDiff = (Time.time - spawnTime) / SHRINK_DURATION;
        // Floating point imprecision guard
        if (timeDiff > 1)
            timeDiff = 1;

        // Shrinking down to zero height
        var scale = transform.localScale;
        scale.y = spawnY * (1 - timeDiff);
        transform.localScale = scale;

        if (timeDiff == 1)
            PhaseManager.Instance.EndGame();
    }
}
