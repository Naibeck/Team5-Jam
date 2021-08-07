using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
    public Button continueButton;
    public Button exitButton;
    public GameObject popup;

    private void Start()
    {
        continueButton.onClick.AddListener(() =>
        {
            Hide();
            // Win condition
        });
    }

    public void Hide() => 
        popup.SetActive(false);

    public void Show() => 
        popup.SetActive(true);
}
