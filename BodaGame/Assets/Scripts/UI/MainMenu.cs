using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string scene;
    public void StartGame() => SceneManager.LoadScene(scene);
    public void Exit() => Application.Quit();


}
