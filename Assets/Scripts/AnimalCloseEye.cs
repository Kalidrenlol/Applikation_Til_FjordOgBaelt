using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;

public class AnimalCloseEye : MonoBehaviour {

	SVGImage animalSVGImage;
	public SVGAsset animalOpenEye;
	public SVGAsset animalClosedEye;
	float timer;
	[SerializeField] float firstBlink = 4f;
	float open;
	float close;
	bool isClosed;

	// Use this for initialization
	void Start () {
		animalSVGImage = gameObject.GetComponent(typeof(SVGImage)) as SVGImage;
		animalOpenEye = animalSVGImage.vectorGraphics;
		isClosed = false;
		open = firstBlink;
		close = 0.2f;
		timer = open;
	}

	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if(timer < 0) {

			if (isClosed) {
				timer += Random.Range(2f, 4f);
				animalSVGImage.vectorGraphics = animalOpenEye;
			} else {
				timer += close;
				animalSVGImage.vectorGraphics = animalClosedEye;
			}

			isClosed = !isClosed;
		}
	}
}