using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCountdown : MonoBehaviour
{
    public GameObject[] Turtles = new GameObject[18];
    public float maxTime = 20f;
    public float currentTime;
    private int turtleIndex;

    public float adultStart;
    public float adultEndoldStart;

    public bool reborn = false;
    public GameObject circleHolder;
    public GameObject gravestone;

    private int status = 0;
    private bool isDead = false;
    public int instance = 0;

    public GameObject[] Messages = new GameObject[6];

    void Start() {
        currentTime = maxTime;
    }
    void Update() {
        currentTime -= Time.deltaTime;
        Adult();
        Old();
        DieOff();
    }
    void Adult() {
        if(currentTime <= adultStart && currentTime > adultEndoldStart && status != 1 && Turtles[turtleIndex].GetComponent<PlayerScript>().isGrounded) {
            Turtles[turtleIndex].SetActive(false);
            turtleIndex++;
            BoundCheck();
            Turtles[turtleIndex].SetActive(true);
            status = 1;
        }
    }
    void Old() {
        if(currentTime <= adultEndoldStart && currentTime > 0 && status != 2 && Turtles[turtleIndex].GetComponent<PlayerScript>().isGrounded) {
            Turtles[turtleIndex].SetActive(false);
            turtleIndex++;
            BoundCheck();
            Turtles[turtleIndex].SetActive(true);
            status = 2;
        }
    }
    public void Rebirth() {
        currentTime = maxTime;
        instance++;
        Turtles[turtleIndex].SetActive(false);
        int i = instance * 3;
        turtleIndex = i;
        Debug.Log(turtleIndex);
        BoundCheck();
        Turtles[turtleIndex].SetActive(true);
        GameObject childObject = Instantiate(gravestone, new Vector2(0,-1.51f), transform.rotation) as GameObject;
        childObject.transform.parent = circleHolder.transform;
        Messages[Mathf.Clamp(instance, 0, 6)].SetActive(true);
    }
    void DieOff() {
        if(currentTime <= 0 && !isDead) {
            Turtles[turtleIndex].GetComponent<PlayerScript>().kill();
        }
    }
    void BoundCheck() {
        if(turtleIndex > 18) {
            turtleIndex -= 3;
        }
    }
}
