using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleTurtle : MonoBehaviour
{
    public GameObject HeartLocation;
    public GameObject Heart;
    Animator anim;
    public GameObject turtleHolder;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")) {
            anim.SetBool("isActive", true);
        }
    }
    public void HeartCreate() {
        Instantiate(Heart, HeartLocation.transform.position, new Quaternion(0, 0, 0, 0));
        turtleHolder.GetComponent<DeathCountdown>().Rebirth();
        gameObject.SetActive(false);
    }
}
