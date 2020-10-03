using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("Deactivator");
    }

    IEnumerator Deactivator() {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
