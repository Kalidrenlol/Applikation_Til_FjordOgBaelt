using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertebraChosen : MonoBehaviour {

	GameObject controller;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("InGameController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void initGame() {
		controller.GetComponent<InGameControllerSpermwhale> ().gameSetup ();
	}
}
