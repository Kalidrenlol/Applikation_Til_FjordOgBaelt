using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropPiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
	
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	public GameObject correctPlace;
	public GameObject controller;

	public void OnBeginDrag (PointerEventData eventData)
	{
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}

	public void OnDrag (PointerEventData eventData)
	{
		transform.position = eventData.position;
	}

	public void OnEndDrag (PointerEventData eventData)
	{
		if (gameObject.GetComponent<Collider2D> ().IsTouching (correctPlace.GetComponent<Collider2D> ())) {
			correctPlace.GetComponent<Image> ().color = gameObject.GetComponent<Image> ().color;
			controller.GetComponent<InGameControllerSpermwhale> ().UpdateProgress ();
			Destroy ();
		} else {
			itemBeingDragged = null;
			transform.position = startPosition;
		}
	}
		
	public void Destroy() {
		Destroy(gameObject);
	}
}
