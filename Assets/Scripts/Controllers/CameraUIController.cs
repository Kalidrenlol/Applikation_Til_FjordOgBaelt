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
	[SerializeField] GameObject cancelButton;
	public Color colorNotclickable;
	public Color colorClickable;

	void OnEnable() {
		GetComponent<Animator>().SetBool("IsLoading", false);
		ColorBlock cb = cancelButton.GetComponent<Button> ().colors;

		cancelButton.GetComponent<Button> ().interactable = true;
		cb.normalColor = colorClickable;
		cancelButton.GetComponent<Button> ().colors = cb;
	}

	public void StartAnimation(string _name) {
		cancelButton.GetComponent<Button> ().interactable = false;
		ColorBlock cb = cancelButton.GetComponent<Button> ().colors;
		cb.normalColor = colorNotclickable;
		cancelButton.GetComponent<Button> ().colors = cb;
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
