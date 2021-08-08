using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float timeRemaining;
    public TextMeshProUGUI timeText;
    public LosePopup losePopup;
    
    public bool IsRunningOutOfTime => 
        timeRemaining < 10f; 
    
    private bool isTimeAvailable;    

    void Start() => 
        isTimeAvailable = true;


    void Update()
    {
        if (isTimeAvailable)
        {
            
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                // trigger lose condition
                isTimeAvailable = false;
                timeRemaining = 0f;
            }

            if (timeRemaining >= 0) 
                displayTime(timeRemaining);
        }
    }

    private void displayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = $"{minutes:00}:{seconds:00}";
    }
}
