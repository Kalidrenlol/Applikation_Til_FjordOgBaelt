using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_ThrowingFish : MonoBehaviour {

	[SerializeField] GameObject WaterSplash;
	Rigidbody rb;

	void OnEnable() {
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
	}

	public void Throw() {
		rb.useGravity = true;
		rb.AddForce(Camera.main.transform.forward * 200f);
	}

	void OnTriggerEnter(Collider col) {
		print(name + " rammer " + col.name);
		if (col.CompareTag("Ground")) {
			GameObject water = Instantiate(WaterSplash, transform.parent);
			water.transform.position = transform.position;
			Destroy(gameObject);
		}
	}

}