using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableFix : MonoBehaviour {
	
	void OnEnable () {
	 	GameObject.FindGameObjectWithTag ("GameController").GetComponent<AnimalsController> ().UpdateAnimals ();
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<ItemController> ().UpdateItems ();
	}
}
