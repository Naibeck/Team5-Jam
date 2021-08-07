using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{
    public void SetDifficulty(float difficultySpeed) => PlayerPrefs.SetFloat("DifficultySpeed", difficultySpeed);
    public void GoToScene(string scene) => SceneManager.LoadScene(scene);
    public void ExitGame() => Application.Quit();


}
