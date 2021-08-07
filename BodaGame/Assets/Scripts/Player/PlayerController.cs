using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float gravityForce;
    public CharacterController controller;
   
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        var moveDirection = new Vector3(0f, 0f, Input.GetAxis("Vertical"));
        
        if (isJumpingKey()) 
            moveDirection.y = jumpForce;

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityForce);
        controller.Move(moveDirection * Time.deltaTime);
    }


    private static bool isJumpingKey() => 
        Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
}
