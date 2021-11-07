using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 7;
    public int jumpForce = 370;
    public float moveX;
    public bool isGround;
    private Animator anim;
    private Rigidbody2D rb;
    private bool mirrered;
    private AudioSource au;
    public AudioClip jumpClip;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGround==true)
        {
            Jump();
        }

        if (!isGround)
        {
            anim.SetBool("ISJUMP",true);
        }

        if (moveX!=0 && isGround)
        {
           anim.SetBool("ISRUN", true);
        }
        else
        {
            anim.SetBool("ISRUN", false);
        }

        if (moveX < 0.0f && mirrered == false)
        {
            FlipPlayer();
        }else if (moveX > 0.0f && mirrered == true)
        {
            FlipPlayer();
        }
        rb.velocity = new Vector2(moveX * speed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    private void FlipPlayer()
    {
        mirrered = !mirrered;
        Vector2 local = gameObject.transform.localScale;
        local.x *= -1;
        transform.localScale = local;
    }

    void Jump()
    {
        rb.AddForce(Vector2.up*jumpForce);
        isGround = false;
        au.clip = jumpClip;
        au.Play();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Ground")
        {
            isGround = true;
            anim.SetBool("ISJUMP", false);
        }
        if (other.gameObject.tag == "Exit")
        {
            Application.LoadLevel("HomeScene");
        }
    }
}
