using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public LosePopup losePopup;
    public WinPopup winPopup;
    public LevelCreator levelCreator;
    public Timer timer;
    public AudioSource music;
    public AudioSource fastPaceMusic;
    public AudioSource loseMusic;
    public AudioSource winMusic;

    private bool isRegularMusicPlaying = true;

    private void Awake()
    {
        levelCreator.CreateLevel();
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
        player.moveSpeed = PlayerPrefs.GetFloat("DifficultySpeed", 5);
        timer.timeRemaining = (PlayerPrefs.GetFloat("DifficultyTimer", 10));
    }

    private void Update()
    {
        if(levelCreator.CheckEnd())
        {
            player.enabled = false;
        }
        if (levelCreator.levelEnd.End)
        {
            if (Time.timeScale != 0)
            {
                winPopup.Show();

                music.Stop();
                fastPaceMusic.Stop();

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
                music.Stop();
                fastPaceMusic.Stop();

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
        else
        {
            var volume = fastPaceMusic.volume;
            if (volume > 0)
            {
                music.volume += 0.05f;
                fastPaceMusic.volume -= 0.05f;
            }
            TriggerFastPacedMusic();
        }
    }
    private void TriggerFastPacedMusic() =>isRegularMusicPlaying = !isRegularMusicPlaying;
    
    private void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(gameObject.scene.name);
    }
}
