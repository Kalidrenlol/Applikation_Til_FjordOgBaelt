using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SVGImporter;

public class DragDropBird : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	public static GameObject itemBeingDragged;
	public GameObject controller;
	Vector3 startPosition;
	public GameObject correctPlace;

	void Start () {
	}

	void Update () {
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
			correctPlace.GetComponent<SVGImage> ().vectorGraphics = gameObject.GetComponent<SVGImage> ().vectorGraphics;
			correctPlace.GetComponent<SVGImage> ().color = new Color32(255,255,255,255);
			controller.GetComponent<InGameControllerSeagull> ().UpdateProgress ();
			Destroy (gameObject);
		} else {
			itemBeingDragged = null;
			transform.position = startPosition;
		}
	}
}
