using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour, IPointerEnterHandler
{ 
    public AudioSource source;
    public AudioClip select;
    public AudioClip click;
    public Button button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        source.clip = select;
        source.pitch = Random.Range(0.9f, 1.1f);
        source.Play();
    }
    public void OnClick()
    {
        source.clip = click;
        source.pitch = Random.Range(0.9f, 1.1f);
        source.Play();
    }

    private void Start()
    {
        button.onClick.AddListener(() => OnClick());
    }

}
