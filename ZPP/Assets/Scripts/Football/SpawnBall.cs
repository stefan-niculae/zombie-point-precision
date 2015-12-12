using UnityEngine;
using System.Collections;

public class SpawnBall : MonoBehaviour {

    private Vector2 upPosition = new Vector2(7f, -2.35f);
    private Vector2 downPosition = new Vector2(7f, -3.5f);
    private Vector2 upDirection = new Vector2(-7.5f, -2.35f);
    private Vector2 downDirection = new Vector2(-7.5f, -3.5f);
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
        GameObject Temp = null;
        position = Random.Range(0, 2);
        direction = Random.Range(0, 2);
        switch (position)
        {
            case 0:
                Temp = (GameObject)Instantiate(ball, upPosition, Quaternion.identity);
                Temp.GetComponent<BallMovement>().SetDirection(upDirection);
                break;
            case 1:
                Temp = (GameObject)Instantiate(ball, downPosition, Quaternion.identity);
                Temp.GetComponent<BallMovement>().SetDirection(downDirection);
                break;
        }

        Temp.transform.parent = container;

/*        switch (direction)
        {
            case 0:
                Temp.GetComponent<BallMovement>().SetDirection(upDirection);
                break;
            case 1:
                Temp.GetComponent<BallMovement>().SetDirection(downDirection);
                break;
        }
*/
    }

}
