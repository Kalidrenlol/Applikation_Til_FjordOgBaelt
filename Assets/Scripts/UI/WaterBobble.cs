using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBobble : MonoBehaviour {

	public int speed;

	void Update () {
		transform.position = transform.position + new Vector3(0, (Screen.height/500), 0);

		speed = (Screen.height / 500);

		if (transform.position.y > Screen.height + 50) {
			Destroy(gameObject);
		}
	}
}
