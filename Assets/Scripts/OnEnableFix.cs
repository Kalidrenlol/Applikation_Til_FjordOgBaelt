using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableFix : MonoBehaviour {

	//[SerializeField] GameObject GameUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable () {
	 	GameObject.FindGameObjectWithTag ("GameController").GetComponent<AnimalsController> ().UpdateAnimals ();
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<ItemController> ().UpdateItems ();
		print ("ENABLED");

	}

	void OnDisable () {
		print ("DISABLED");
	}
}
