using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject ScoreKeeper;
    AudioSource source;
    public AudioClip pop;

    void Awake() {
        ScoreKeeper = GameObject.FindWithTag("Manager");
        source = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            ScoreKeeper.GetComponent<ScoreKeep>().currentScore++;
            source.PlayOneShot(pop);
            Destroy(gameObject, pop.length);
        }
    }
}
