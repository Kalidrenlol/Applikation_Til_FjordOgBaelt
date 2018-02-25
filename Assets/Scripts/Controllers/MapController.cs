using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class MapController : MonoBehaviour {
	Animator animFirst;
	Animator animGround;
	Animator animBasement;

	public GameObject mapFirst;
	public GameObject mapGround;
	public GameObject mapBasement;

	public GameObject buttonFirst;
	public GameObject buttonGround;
	public GameObject buttonBasement;

	public GameObject buttons;
	public GameObject infoBox;

	public GameObject[] pointers;

	private Color selectedColor = new Color32 (186, 255, 201, 255);
	private Color PointerFoundColor  = new Color32(154, 184, 244, 255);

	void Start () {
		animFirst = mapFirst.GetComponent<Animator> ();
		animGround = mapGround.GetComponent<Animator> ();
		animBasement = mapBasement.GetComponent<Animator> ();
	}

	void Update () { }

	public void changeFloor(string floor) {
		if (floor == "-1") {
			mapBasement.SetActive (true);
			mapGround.SetActive (false);
			mapFirst.SetActive (false);
			buttonFirst.GetComponent<Image> ().color = Color.white;
			buttonGround.GetComponent<Image> ().color = Color.white;
			buttonBasement.GetComponent<Image> ().color = selectedColor;
		} else if (floor == "0") {
			mapBasement.SetActive (false);
			mapGround.SetActive (true);
			mapFirst.SetActive (false);
			buttonFirst.GetComponent<Image> ().color = Color.white;
			buttonGround.GetComponent<Image> ().color = selectedColor;
			buttonBasement.GetComponent<Image> ().color = Color.white;
		} else if (floor == "1") {
			mapBasement.SetActive (false);
			mapGround.SetActive (false);
			mapFirst.SetActive (true);
			buttonFirst.GetComponent<Image> ().color = selectedColor;
			buttonGround.GetComponent<Image> ().color = Color.white;
			buttonBasement.GetComponent<Image> ().color = Color.white;
		}
	}

	public void ZoomToFirst(int room) {
		if (!animFirst.GetBool ("ZoomTo"+room)) {
			animFirst.SetBool ("ZoomTo"+room, true);
			buttons.SetActive (false);
			infoBox.SetActive (false);
		} else if(animFirst.GetBool("ZoomTo"+room)) {
			animFirst.SetBool ("ZoomTo"+room, false);
			buttons.SetActive (true);
			infoBox.SetActive (true);
		}
	}

	public void ZoomToGround(int room) {
		if (!animGround.GetBool ("ZoomTo"+room)) {
			animGround.SetBool ("ZoomTo"+room, true);
			buttons.SetActive (false);
			infoBox.SetActive (false);
		} else if(animGround.GetBool("ZoomTo"+room)) {
			animGround.SetBool ("ZoomTo"+room, false);
			buttons.SetActive (true);
			infoBox.SetActive (true);
		}
	}

	public void ZoomToBasement(int room) {
		if (!animBasement.GetBool ("ZoomTo"+room)) {
			animBasement.SetBool ("ZoomTo"+room, true);
			buttons.SetActive (false);
			infoBox.SetActive (false);
		} else if(animBasement.GetBool("ZoomTo"+room)) {
			animBasement.SetBool ("ZoomTo"+room, false);
			buttons.SetActive (true);
			infoBox.SetActive (true);
		}
	}

	public void changePointerToFound(string name) {
		for (int i = 0; i < pointers.Length; i++) {
			if (pointers [i].name == name) {
				pointers [i].gameObject.transform.GetChild(2).gameObject.GetComponent<SVGImage> ().color = Color.white;
				pointers [i].gameObject.transform.GetChild(0).gameObject.GetComponent<SVGImage> ().color = PointerFoundColor;
				break;
			}
		}
	}
}
