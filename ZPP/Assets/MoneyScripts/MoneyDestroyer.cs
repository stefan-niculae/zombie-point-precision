using UnityEngine;
using System.Collections;

public class MoneyDestroyer : MonoBehaviour {
    //Cand un obiect atinge Collider-ul se distruge
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}   

