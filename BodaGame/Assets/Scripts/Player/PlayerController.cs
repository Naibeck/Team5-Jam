using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public Rigidbody player;
    
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isJumpingKey()) 
            Jump();
    }


    private Vector3 Jump() => 
        player.velocity = new Vector3(player.velocity.x, jumpForce, player.velocity.z);

    private static bool isJumpingKey() => 
        Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
}
