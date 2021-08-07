using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    public float jumpForce;
    public Rigidbody player;
    
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movePlayer();

        if (isJumping()) 
            Jump();
    }

    private void movePlayer() =>
        player.velocity = new Vector3(Input.GetAxis("Horizontal") * movementSpeed, player.velocity.y,
            player.velocity.z);

    private Vector3 Jump() => 
        player.velocity = new Vector3(player.velocity.x, jumpForce, player.velocity.z);

    private static bool isJumping() => 
        Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
}
