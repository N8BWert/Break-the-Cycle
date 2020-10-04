using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTop : MonoBehaviour
{
    public GameObject[] Sprites = new GameObject[8];

    private int spriteIndex = 0;

    public bool isTop = false;
    public GameObject femaleTurtle;

    public bool isBottom = false;
    public GameObject[] Coins = new GameObject[5];
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    private int index = 0;
    public GameObject CircleHolder;

    public bool canSpawn = true;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && canSpawn) {
            Sprites[spriteIndex].SetActive(false);
            spriteIndex ++;
            Mathf.Clamp(spriteIndex, 0, 7);
            if(spriteIndex > 7) { spriteIndex = 7; }
            Sprites[spriteIndex].SetActive(true);
            if(isTop) {
                femaleTurtle.SetActive(true);
            }
            if(isBottom) {
                GameObject child1 = Instantiate(Coins[Mathf.Clamp(index, 0, 4)], spawn1.transform.position, spawn1.transform.rotation) as GameObject;
                GameObject child2 = Instantiate(Coins[Mathf.Clamp(index, 0, 4)], spawn2.transform.position, spawn2.transform.rotation) as GameObject;
                GameObject child3 = Instantiate(Coins[Mathf.Clamp(index, 0, 4)], spawn3.transform.position, spawn3.transform.rotation) as GameObject;
                child1.transform.parent = CircleHolder.transform;
                child2.transform.parent = CircleHolder.transform;
                child3.transform.parent = CircleHolder.transform;
                index++;
            }
            StartCoroutine("waitTime");
        }
    }
    IEnumerator waitTime() {
        canSpawn = false;
        yield return new WaitForSeconds(2);
        canSpawn = true;
    }
}
