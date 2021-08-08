using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Timer timer;
    public float addTime;
    public LayerMask playerLayer;
    void Start()
    {

        if(!(Random.Range(0,PlayerPrefs.GetInt("DifficultyPowerUp", 1)) < 1))
        {
            Destroy(gameObject);
        }
        timer = GameObject.FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            timer.timeRemaining += addTime;
            Destroy(gameObject);
        }

    }
}
