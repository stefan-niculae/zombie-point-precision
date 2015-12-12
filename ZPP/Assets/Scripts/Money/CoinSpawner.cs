using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	[SerializeField]
    GameObject prefab;
    [SerializeField]
    Transform container;

    [SerializeField]
    float minXSpawn;
	[SerializeField]
    float maxXSpawn;
    [SerializeField]
    float YSpawn;

    bool isSpawning = true;
    readonly float SPAWN_INTERVAL = 1f; // in seconds
    float lastSpawn;

    void Start()
    {
        Spawn();
    }

    void Update()
	{
        if (isSpawning && Time.time - lastSpawn >= SPAWN_INTERVAL)
            Spawn();
    }

    void Spawn()
	{
        lastSpawn = Time.time;

        Vector3 pos = new Vector3(
			Random.Range(minXSpawn, maxXSpawn),
			YSpawn,
			container.localPosition.z
        );

        var spawned = Instantiate(
            prefab,
            pos,
            Quaternion.identity
        ) as GameObject;

        spawned.transform.parent = container;
    }
}
