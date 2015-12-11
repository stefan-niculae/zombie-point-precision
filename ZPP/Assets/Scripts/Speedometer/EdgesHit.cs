using UnityEngine;
using System.Collections;

public class EdgesHit : MonoBehaviour {

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        if(other.gameObject.name == "needleEdge")
        {
            Debug.Log("NEEDLE");
            Time.timeScale = 0;
        }
    }
}
