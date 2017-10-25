using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class AnimalObject : MonoBehaviour {

	Animal animal;
	Animator animator;

	[SerializeField] Text txtName;
	[SerializeField] SVGImage imgImage;
	GameObject obj;

	void OnEnable() {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(ShowTask);
		animator = GetComponent<Animator>();
	}

	public void Setup(Animal ani, GameObject go) {
		obj = go;
		animal = ani;
		imgImage.vectorGraphics = ani.assetOpen;
		animator = GetComponent<Animator>();
		txtName.text = ani.danishName;
		bool hasSeen = (PlayerPrefs.GetInt(ani.englishName + "_hasSeen") == 0) ? false : true;
		bool newDiscover = (PlayerPrefs.GetInt(ani.englishName + "_newDiscover") == 0) ? false : true;
		ani.HasSeen = hasSeen;
		ani.NewDiscover = newDiscover;

		if (ani.NewDiscover) {
			animator.SetTrigger("Discover");
			//Debug.Log(ani.englishName + " :discovered trigger");
		} else if (ani.HasSeen) {
			animator.SetBool("Discovered", true);
			//Debug.Log(ani.englishName + " :discovered");
		} else {
			//Debug.Log(ani.englishName + " :not discovered");
			txtName.gameObject.SetActive(false);
			imgImage.color = Color.black;
			animator.SetBool("Discovered", false);
		}
	}

	void IsDiscovered() {
		animator.SetBool("Discovered", true);
		PlayerPrefs.SetInt(animal.englishName + "_newDiscover", 0);
		animal.NewDiscover = false;
		CreateStars();
	}

	void CreateStars() {
		AnimalsController controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<AnimalsController>();
			GameObject star = Instantiate(controller.starPrefab, controller.juicynessFolder);
			star.transform.position = obj.transform.position;
	}
		
	void ShowAnimal() {
		GameObject animalView =	GameObject.FindGameObjectWithTag("GameController").GetComponent<AnimalsController>().animalView;
		animalView.GetComponent<AnimalView>().ShowPage(true);
		animalView.GetComponent<AnimalView>().Setup(animal.GetComponent<Animal>());
	}

	void ShowTask() {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().ShowAnimalView(animal);
	}
}
