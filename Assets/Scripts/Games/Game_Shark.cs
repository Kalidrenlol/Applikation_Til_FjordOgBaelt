using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;

public class Game_Shark : MonoBehaviour {

	public SVGAsset noTooth;

	void Start() {
		GetComponent<InGameController>().animalImg.vectorGraphics = noTooth;
	}
}
