using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInteraction : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public bool Pressed = false;
 
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
    }
 
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}
