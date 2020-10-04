using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleTurtle : MonoBehaviour
{
    public GameObject HeartLocation;
    public GameObject Heart;
    Animator anim;
    public GameObject turtleHolder;

    AudioSource source;
    public AudioClip kiss;

    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            anim.SetBool("isActive", true);
            source.PlayOneShot(kiss);
        }
    }
    public void HeartCreate() {
        Instantiate(Heart, HeartLocation.transform.position, new Quaternion(0, 0, 0, 0));
        turtleHolder.GetComponent<DeathCountdown>().Rebirth();
        gameObject.SetActive(false);
    }
}
