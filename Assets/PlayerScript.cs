using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject Tombstone;
    public GameObject Rotator;

    public bool isGrounded = true;
    private Vector2 JumpVector;
    public float JumpVelocity = 0.1f;
    public float gravity = 0.05f;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }
    void Update() {
        GroundCheck();
        if(isGrounded) {
            if(Input.GetButtonDown("Jump")) {
                JumpVector.y = JumpVelocity;
            } 
            else { JumpVector.y = 0; }
        }
        if(!isGrounded) {
            JumpVector.y -= gravity * Time.deltaTime;
        }
        gameObject.transform.Translate(JumpVector);
        MovementCheck();
    }
    void GroundCheck() {
        if(gameObject.transform.position.y <= -2.97) {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
        else {
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
        if(isGrounded) {
            anim.SetBool("isGrounded", true);
        }
    }

    void MovementCheck() {
        if(Input.GetAxisRaw("Horizontal") != 0) {
            anim.SetBool("isMoving", true);
        }
        else {
            anim.SetBool("isMoving", false);
        }
    }

    public void kill() {
        Instantiate(Tombstone, new Vector2(0,-1.51f), transform.rotation);
        Rotator.GetComponent<RotateWorld>().canMove = false;
        Destroy(gameObject);
    }
}
