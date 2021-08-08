using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    public void SetDifficultySpeed(float difficultySpeed) =>
        PlayerPrefs.SetFloat("DifficultySpeed", difficultySpeed);

    public void SetDifficultyTimer(float difficultyTimer) => 
        PlayerPrefs.SetFloat("DifficultyTimer", difficultyTimer);
    public void SetDifficultyPowerUp(int difficultyTimer) =>
        PlayerPrefs.SetInt("DifficultyPowerUp", difficultyTimer);
    public void GoToScene(string scene) => SceneManager.LoadScene(scene);
    public void ExitGame() => Application.Quit();

}
