using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {

	public GameObject controller;
	public bool fresh;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("InGameController");
	}
	
	// Update is called once per frame
	public int speed;

	void Update () {
		transform.position = transform.position - new Vector3(0, (Screen.height/500), 0);

		speed = (Screen.height / 500);

		if (transform.position.y < 0 - 50) {
			controller.GetComponent<InGameControllerPorpoise2>().SpawnFish();
			Destroy(gameObject);
		}
	}

	void OnTriggerStay2D (Collider2D ol)
	{
		print ("COLLISION");

		if (fresh) {
			controller.GetComponent<InGameControllerPorpoise2> ().UpdateProgress (1);
		} else  {
			controller.GetComponent<InGameControllerPorpoise2> ().UpdateProgress (-1);
		}
		controller.GetComponent<InGameControllerPorpoise2>().SpawnFish();
		Destroy(gameObject);
	}
}
