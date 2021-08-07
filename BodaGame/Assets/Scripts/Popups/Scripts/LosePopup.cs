using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePopup : MonoBehaviour
{
    public Button exitButton;
    public Button restartButton;
    public GameObject popup;

    public void Show() => 
        popup.SetActive(true);

    public void Hide() => 
        popup.SetActive(false);
}
