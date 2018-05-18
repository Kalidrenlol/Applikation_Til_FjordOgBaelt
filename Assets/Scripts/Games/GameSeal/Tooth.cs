using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class Tooth : MonoBehaviour {
	
	public GameObject controller;
	public int collisionCounter;

	void Start () {
		collisionCounter = 0;
	}

	void OnTriggerStay2D(Collider2D ol) {
		controller.GetComponent<InGameControllerSeal> ().StartBrushBobbles ();
		switch (collisionCounter) {
			case 25: 
				gameObject.GetComponent<Image>().color = new Color32 (199, 199, 88, 255);
				break;
			case 50: 
				gameObject.GetComponent<Image>().color = new Color32 (234, 234, 169, 255);
				break;
			case 75: 
				gameObject.GetComponent<Image>().color = new Color32 (255, 255, 255, 255);
			controller.GetComponent<InGameControllerSeal>().UpdateProgress();
				break;
		}
		collisionCounter++;
	}
}
