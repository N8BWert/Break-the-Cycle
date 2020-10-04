using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject Tombstone;
    public GameObject Rotator;

    public bool isGrounded = true;
    private Vector2 JumpVector;
    public float JumpVelocity = 0.1f;
    public float gravity = 0.05f;

    private Animator anim;
    public AudioClip gameOver;

    private Rigidbody2D rb;
    public bool onPlatform = false;

    public GameObject restartButton;
    public GameObject menuButton;
    public GameObject TurtleHolder;

    public Text endCounterText;

    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        GroundCheck();
        if(isGrounded && Input.GetButtonDown("Jump")) {
            rb.velocity = new Vector2(0, JumpVelocity);
        }
        else if(isGrounded && !Input.GetButtonDown("Jump")) {
            //rb.velocity = Vector2.zero;
            gameObject.transform.rotation = Quaternion.identity;
        }
        MovementCheck();
    }
    void GroundCheck() {
        if(gameObject.transform.position.y <= -2.97 && !onPlatform) {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
        else if(gameObject.transform.position.y > -2.97 && !onPlatform){
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
        if(onPlatform) {
            isGrounded = true;
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
        TurtleHolder.GetComponent<AudioSource>().PlayOneShot(gameOver);
        endCounterText.text = "It took you " + TurtleHolder.GetComponent<DeathCountdown>().instance + " generations to break the cycle.";
        Instantiate(Tombstone, new Vector2(0,-1.51f), transform.rotation);
        Rotator.GetComponent<RotateWorld>().canMove = false;
        Destroy(gameObject);
        restartButton.SetActive(true);
        menuButton.SetActive(true);
    }
}
