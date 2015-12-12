using UnityEngine;
using System.Collections;

public class MoneyGameControler : MonoBehaviour {

    public GameObject coin;
    public Camera cam;
    
    
    private float maxWidth;
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float coinWidth = coin.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - coinWidth;
        StartCoroutine(SpawnCoin());
        
    }

   

    
    IEnumerator SpawnCoin()
    {
        yield return new WaitForSeconds(1.0f);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(
                                                Random.Range(-maxWidth+5, maxWidth-2),
                                                transform.position.y,
                                                0.0f
                                                );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(coin, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(2.0f, 3.0f));
        }
        
    }
}
