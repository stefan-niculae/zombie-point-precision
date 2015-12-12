using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

    readonly Vector2 UP_POS = new Vector2(7f, -1.9f);
    readonly Vector2 DOWN_POS = new Vector2(7f, -3.5f);
    private int position;
    private int direction;

    public GameObject ball;
    private Transform container;

    void Start()
    {
        container = GameObject.Find("ballContainer").transform;
        StartCoroutine(WaitAndSpawn());
    }

    IEnumerator WaitAndSpawn()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        InstatiateBall();
        StartCoroutine(WaitAndSpawn());
    }

    void InstatiateBall()
    {
        GameObject spawned = null;
        position = Random.Range(0, 2);
        direction = Random.Range(0, 2);
        switch (position)
        {
            case 0:
                spawned = Instantiate(ball, UP_POS, Quaternion.identity) as GameObject;
                spawned.GetComponent<BallMovement>().SetBounceDir(direction);
                break;
            case 1:
                spawned = Instantiate(ball, DOWN_POS, Quaternion.identity) as GameObject;
                spawned.GetComponent<BallMovement>().SetBounceDir(direction);
                break;
        }

        spawned.transform.parent = container;
    }
}
