using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SVGImporter;

public class AnimalView : MonoBehaviour{

	Animator anim;

	[SerializeField] Text txtName;
	[SerializeField] SVGImage imgSprite;
	[SerializeField] GameObject NoSeen;
	[SerializeField] Button NoSeenBtn;
	[SerializeField] GameObject Seen;
	[SerializeField] GameObject Map;

	float _pressedY;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator>();
	}

	public void ShowPage(bool _bool) {
		anim.SetBool("Show", _bool);
		GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().TopBar.GetComponent<Animator>().SetBool("Show", !_bool);
		int animalsSeen = GameObject.FindGameObjectWithTag("GameController").GetComponent<AnimalsController>().GetAnimalSeen();

		if (!_bool && PlayerPrefs.GetInt("ShowTutorial") == 7 && animalsSeen > 0) {
			GameObject tut = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().tutorialGO;
			tut.SetActive(true);
			tut.GetComponent<TutorialController>().GoToState(10);
		}
	}

	public void Setup(Animal ani) {
		imgSprite.vectorGraphics = ani.assetOpen;

		if (ani.HasSeen) {
			NoSeen.SetActive(false);
			Seen.SetActive(true);
			txtName.text = ani.danishName;
			imgSprite.color = Color.white;
		} else {
			NoSeenBtn.onClick.RemoveAllListeners();
			NoSeenBtn.onClick.AddListener(delegate {
				ShowPage(false);
				GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().MenuObject.GoToScreen(0);
				GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().MenuObject.GoToScreen(0);
				Map.gameObject.GetComponent<MapController>().highlightAnimal(ani.englishName);
				Debug.Log(ani.englishName);
				Debug.Log(Map.gameObject.GetComponent<MapController>());
			});
			NoSeen.SetActive(true);
			Seen.SetActive(false);
			txtName.text = "Ukendt";
			imgSprite.color = Color.black;
		}

		ShowPage(true);
	}

	public void Setup(Item _item) {
		imgSprite.vectorGraphics = _item.asset;

		if (_item.HasSeen) {
			NoSeen.SetActive(false);
			Seen.SetActive(true);
			txtName.text = _item.danishName;
			imgSprite.color = Color.white;
		} else {
			NoSeenBtn.onClick.RemoveAllListeners();
			NoSeenBtn.onClick.AddListener(delegate {
				ShowPage(false);
				GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().MenuObject.GoToScreen(0);
			});
			NoSeen.SetActive(true);
			Seen.SetActive(false);
			txtName.text = "Ukendt";
			imgSprite.color = Color.black;
		}

		ShowPage(true);
	}
}
