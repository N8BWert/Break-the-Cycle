using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    public float moveSpeed = 1f;
    public bool canMove = true;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") != 0 && canMove)
        {
            gameObject.transform.Rotate(0, 0, Mathf.Abs(Input.GetAxis("Horizontal")) * -Time.deltaTime * moveSpeed, Space.Self);
        }
    }
}
