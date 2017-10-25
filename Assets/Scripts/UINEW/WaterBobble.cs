using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBobble : MonoBehaviour {

	public int speed = 1;

	void Update () {
		transform.position = transform.position + new Vector3(0, 0.3f * speed, 0);

		if (transform.position.y > 1400) {
			Destroy(gameObject);
		}
	}
}
