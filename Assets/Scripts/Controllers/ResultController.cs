using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class ResultController : MonoBehaviour {

	public GameObject statusTextWrapper;
	public Button resultBtn;
	public GameObject achievementWrapper;
	public GameObject achievementText;
	public SVGImage resultsAnimalImage;

	public void Setup(string _name, bool _correct) {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		Animal ani = controller.GetComponent<AnimalsController>().GetAnimal(_name);
		resultsAnimalImage.vectorGraphics = ani.assetOpen;
		print(_name);
		if (_correct) {
			GetComponent<Animator>().SetTrigger("Correct");
		}
	}

	public void PlaySound() {
		GetComponent<AudioSource> ().Play ();
	}
}
