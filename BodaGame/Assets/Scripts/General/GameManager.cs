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

    private void Awake()
    {
        levelCreator.CreateLevel(ref levelMove);
        timer.losePopup = losePopup;
        timer.timeRemaining = (PlayerPrefs.GetFloat("DifficultyTimer", 45));
    }

    private void Start()
    {
        levelMove.moveSpeed = PlayerPrefs.GetFloat("DifficultySpeed", 5);
    }

    private void Update()
    {
        if (levelMove.levelEnd.End)
            winPopup.Show();
    }


}
