using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void SetDifficultySpeed(float difficultySpeed) =>
        PlayerPrefs.SetFloat("DifficultySpeed", difficultySpeed);

    public void SetDifficultyTimer(float difficultyTimer) => 
        PlayerPrefs.SetFloat("DifficultyTimer", difficultyTimer);
    public void GoToScene(string scene) => SceneManager.LoadScene(scene);
    public void ExitGame() => Application.Quit();

}
