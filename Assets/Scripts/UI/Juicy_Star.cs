using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class Juicy_Star : MonoBehaviour {

	SVGImage target;

	void Start() {
		target = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().iconTrophy;
	}

	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target.gameObject.transform.position, 15f);
		if (target.gameObject.transform.position == transform.position) {
			GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().AllAnimalsSeen(false);
			Destroy(gameObject);
			//PlaySound
		}
	}
}
