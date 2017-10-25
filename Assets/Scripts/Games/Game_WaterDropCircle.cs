using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_WaterDropCircle : MonoBehaviour {

	float destroy;

	void Start() {
		destroy = Random.Range(1.5f, 2.5f);
	}

	void Update () {
		transform.localScale += new Vector3(0.015f, 0, 0.015f);

		if (transform.localScale.x > destroy) {
			Destroy(gameObject);
		}
	}
}
