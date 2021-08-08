using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public AudioSource collisionAudio;
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
    bool isGrounded()
    {
        var colliders = Physics.OverlapBox(transform.position + new Vector3(0, -maxDistanceToGround),
        new Vector3(1, 1, 1), transform.rotation).ToList();
        colliders.Remove(GetComponent<Collider>());
        return colliders.Count > 0;
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (!collisionAudio.isPlaying)
        {
            collisionAudio.pitch = Random.Range(0.8f, 2f);
            collisionAudio.Play();
        }
    }

}
