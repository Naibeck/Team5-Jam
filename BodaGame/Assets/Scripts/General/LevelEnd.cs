using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public bool End;
    public LayerMask playerLayer;
    private void Start() => End = false;
    
    private void OnTriggerEnter(Collider other)
    {
        if(playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            End = true;
        }
    }
}
