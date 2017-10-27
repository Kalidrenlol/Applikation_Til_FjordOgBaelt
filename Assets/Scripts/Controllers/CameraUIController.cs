using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class CameraUIController : MonoBehaviour {

	string animalName;
	[SerializeField] SVGImage flashImg;
	[SerializeField] SVGAsset noFlash;
	[SerializeField] SVGAsset flash;

	void OnEnable() {
		GetComponent<Animator>().SetBool("IsLoading", false);
	}

	public void StartAnimation(string _name) {
		animalName = _name;
		GetComponent<Animator>().SetBool("IsLoading", true);
		GetComponent<AudioSource> ().Play ();
	}

	public void ShowAnimal() {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ShowAnimal(animalName);
	}

	public void ToggleFlash() {
		bool _flash = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ToggleFlash();
		if (flash) {
			flashImg.vectorGraphics = (_flash) ? flash : noFlash;
		}
	}

}
