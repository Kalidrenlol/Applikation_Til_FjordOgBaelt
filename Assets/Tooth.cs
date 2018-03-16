using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooth : MonoBehaviour {

	public int whitelevel;
	public bool isClean;
	public GameObject controller;

	void Start () {
		whitelevel = 115;
		isClean = false;
	}

	void Update () {
		if (whitelevel > 230 && isClean == false) {
			isClean = true;
		}
	}
}
