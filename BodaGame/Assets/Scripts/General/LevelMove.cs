using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    public float moveSpeed;
    public float moveAmount;
    public Transform level;

    void Update()
    {
        Move();
    }

    void Move() => level.position = Vector3.MoveTowards(level.position, new Vector3(level.position.x + moveAmount, 0), Time.deltaTime * moveSpeed);
}
