using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LosePopup losePopup;
    public WinPopup winPopup;
    public LevelCreator levelCreator;
    public LevelMove levelMove;
    public Timer timer;
    public AudioSource music;
    public AudioSource fastPaceMusic;

    private bool isRegularMusicPlaying = true;

    private void Awake()
    {
        levelCreator.CreateLevel(ref levelMove);
        timer.losePopup = losePopup;
        timer.timeRemaining = (PlayerPrefs.GetFloat("DifficultyTimer", 45));
    }

    private void Start()
    {
        fastPaceMusic.volume = 0;
        levelMove.moveSpeed = PlayerPrefs.GetFloat("DifficultySpeed", 5);
    }

    private void Update()
    {
        if (levelMove.levelEnd.End)
            winPopup.Show();
    }

    private void FixedUpdate()
    {
        if (timer.IsRunningOutOfTime && isRegularMusicPlaying)
        {
            var volume = music.volume;
            if (volume > 0)
            {
                music.volume -= 0.05f;
                fastPaceMusic.volume += 0.05f;    
            }        
            else
                TriggerFastPacedMusic();

        }
    }

    private void TriggerFastPacedMusic()
    {
        isRegularMusicPlaying = false;
    }
}
