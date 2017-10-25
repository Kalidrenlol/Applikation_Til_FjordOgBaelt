using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_WaterDrop : MonoBehaviour {

	[SerializeField] GameObject DropCircle;

	void OnTriggerEnter(Collider col) {
		print(name + " rammer " + col.name);

		if (transform.position.y < GameObject.FindGameObjectWithTag("Ground").transform.position.y) {
			GameObject circle = Instantiate(DropCircle);
			circle.transform.position = GameObject.FindGameObjectWithTag("Ground").transform.position + new Vector3(0, 0.3f, 0);
			Destroy(gameObject);
		}
	}
}
