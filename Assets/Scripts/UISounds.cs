using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISounds : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioSource zvukHover;
    public AudioSource zvukPressed;

    public void OnPointerEnter(PointerEventData eventData)
    {
        zvukHover.Play();
        Debug.Log("asdsa");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        zvukPressed.Play();
    }
}
