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
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Jump();
        Crouch();
    }

    void Jump()
    {
        if (isGrounded())
            if (Input.GetButtonDown("Jump"))
                rigidbody.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
    }
    void Crouch()
    {
        //if (Input.GetButtonDown("Crouch")) ;
    }
    bool isGrounded() => Physics.Raycast(transform.position, transform.up * -1, maxDistanceToGround);
}
