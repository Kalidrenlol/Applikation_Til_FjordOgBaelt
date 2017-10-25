using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : MonoBehaviour {

	[SerializeField] GameObject waterDrop;

	public int speed = 200;

	void Start() {
		int count = Random.Range(5, 8);

		for (int i = 0; i < count; i++) {
			GameObject drop = Instantiate(waterDrop, transform);
			drop.GetComponent<Rigidbody>().AddForce(Vector3.up * speed * Random.Range(0.5f,1.5f));
			drop.GetComponent<Rigidbody>().AddForce(Vector3.right * speed / 2 * Random.Range(-1f,1f));

		}
		count = Random.Range(5,8);
		for (int i = 0; i < count; i++) {
			GameObject drop = Instantiate(waterDrop, transform);
			drop.GetComponent<Rigidbody>().AddForce(Vector3.up * speed * Random.Range(0.5f,1.5f));
			drop.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed / 2 * Random.Range(-1f,1f));

		}
	}
}
