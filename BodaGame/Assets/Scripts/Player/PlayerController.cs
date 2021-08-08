using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
 
public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float gravityForce;
    public float maxDistanceToGround;
    public float moveSpeed;
    public Animator animator;
    public AudioSource jumpAudio;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
        Crouch();
        Move();
    }

    void Animation()
    {
        animator.SetFloat("Speed", rigidbody.velocity.x);
        animator.SetFloat("JumpSpeed", rigidbody.velocity.y);
    }
    void Move()
    {
        rigidbody.velocity = new Vector3(moveSpeed, rigidbody.velocity.y);
    }
    void Jump()
    {
        if (isGrounded())
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce);
                jumpAudio.pitch = Random.Range(0.9f, 1.1f);
                jumpAudio.Play();
            }
    }
    void Crouch()
    {
        //if (Input.GetButtonDown("Crouch")) ;
    }
    bool isGrounded() => Physics.Raycast(transform.position, transform.up * -1, maxDistanceToGround);
}
