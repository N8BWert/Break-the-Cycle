using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject ScoreKeeper;

    void Awake() {
        ScoreKeeper = GameObject.FindWithTag("Manager");
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            ScoreKeeper.GetComponent<ScoreKeep>().currentScore++;
            Destroy(gameObject);
        }
    }
}
