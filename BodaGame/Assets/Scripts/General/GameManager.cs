using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public LosePopup losePopup;
    public WinPopup winPopup;
    public LevelCreator levelCreator;
    public LevelMove levelMove;
    public Timer timer;
    public AudioSource music;
    public AudioSource fastPaceMusic;
    public AudioSource loseMusic;
    public AudioSource winMusic;

    private bool isRegularMusicPlaying = true;

    private void Awake()
    {
        levelCreator.CreateLevel(ref levelMove);
        timer.losePopup = losePopup;
        winPopup.continueButton.onClick.AddListener(() => { RestartLevel();});
        winPopup.exitButton.onClick.AddListener(() => { ReturnToMenu(); });
        losePopup.exitButton.onClick.AddListener(() => ReturnToMenu());
        losePopup.restartButton.onClick.AddListener(() => RestartLevel()); 
    }

    private void Start()
    {
        StartTime();
        fastPaceMusic.volume = 0;
        levelMove.moveSpeed = PlayerPrefs.GetFloat("DifficultySpeed", 5);
        timer.timeRemaining = (PlayerPrefs.GetFloat("DifficultyTimer", 51));
    }

    private void Update()
    {
        if (levelMove.levelEnd.End)
        {
            if (Time.timeScale != 0)
            {
                winPopup.Show();

                if (isRegularMusicPlaying)
                    music.Stop();
                else fastPaceMusic.Stop();

                if (!winMusic.isPlaying) winMusic.Play();

                StopTime();
            }
        }
        else if (timer.timeRemaining <= 0)
        {
            if(Time.timeScale != 0)
            {
                Debug.Log("Hello");
                losePopup.Show();
                if (isRegularMusicPlaying)
                    music.Stop();
                else fastPaceMusic.Stop();

                if (!loseMusic.isPlaying) loseMusic.Play();

                StopTime();

            }
        }
    }
    private void StopTime() => Time.timeScale = 0;
    private void StartTime() => Time.timeScale = 1;
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
    private void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
