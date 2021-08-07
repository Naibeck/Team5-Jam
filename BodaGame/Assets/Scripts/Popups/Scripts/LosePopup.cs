using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LosePopup : MonoBehaviour
{
    public Button exitButton;
    public Button restartButton;
    public GameObject popup;

    private void Start()
    {
        restartButton.onClick.AddListener(() => {
            // Restart
            Hide();
            
        });
        
        exitButton.onClick.AddListener(() =>
        {
            Hide();
            // Exit
        });
    }

    public void Show() => 
        popup.SetActive(true);

    public void Hide() => 
        popup.SetActive(false);
}
