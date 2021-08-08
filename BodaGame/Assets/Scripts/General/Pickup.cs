using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Timer timer;
    public float addTime;
    public LayerMask playerLayer;
    public AudioSource source;
    public GameObject cake;
    void Start()
    {
        if(!(Random.Range(0,PlayerPrefs.GetInt("DifficultyPowerUp", 1)) < 1))
        {
            gameObject.SetActive(false);
        }
        timer = GameObject.FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            timer.timeRemaining += addTime;
            source.Play();
            cake.SetActive(false);
        }
    }
}
