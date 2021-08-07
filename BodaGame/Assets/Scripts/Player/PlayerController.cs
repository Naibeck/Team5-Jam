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
        if (isGrounded())
            if (isJumpingKey())
                rigidbody.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
    }
    bool isGrounded() => Physics.Raycast(transform.position, transform.up *-1, maxDistanceToGround);
    private static bool isJumpingKey() => 
        Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
}
