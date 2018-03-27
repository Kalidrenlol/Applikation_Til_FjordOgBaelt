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
	public int delay;
	public Animator animator;
	public GameObject next;

	void Start() {
		animator = GetComponent<Animator> ();
	}

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
			correctPlace.GetComponent<Image> ().sprite = gameObject.GetComponent<Image> ().sprite;
			correctPlace.GetComponent<Image> ().color = new Color32(255,255,255,255);
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

	public void AnimationStart() {
		next.GetComponent<Animator>().SetTrigger ("animate");
	}

	public void AnimationDestroy() {
		Destroy (animator);
	}
}
