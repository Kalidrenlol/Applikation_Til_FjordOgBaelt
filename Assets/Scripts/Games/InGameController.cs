using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class InGameController : MonoBehaviour {

	public string animalName;
	Animal animal;
	[SerializeField] Button btnBag;
	[SerializeField] GameObject bagPrefab;
	[SerializeField] GameObject bagItemPrefab;
	public SVGImage animalImg;
	[SerializeField] Transform canvas;
	[SerializeField] GameObject ShowWinningPrefab;

	GameObject tutorial;
	GameObject gameController;

	void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController");

		btnBag.onClick.AddListener(delegate {
			GameObject bag = Instantiate(bagPrefab, canvas);
			bag.transform.parent = btnBag.transform;
			//bag.GetComponent<BagController>().animal = gameController.GetComponent<AnimalsController>().GetAnimal("Shark");
		});
		//animal = gameController.GetComponent<AnimalsController>().GetAnimal(animalName);
	}

	public void GetItem(Item item) {
		GameObject go = Instantiate(bagItemPrefab, canvas);
		go.GetComponent<Game_BagGO>().img.vectorGraphics = item.asset;
		go.GetComponent<Game_BagGO>().item = item;
	}

	public void GiveItemToAnimal(Item item) {
		Item _item = gameController.GetComponent<ItemController>().GetItem(animal.itemNeeded);
		if (_item == item) {
			animalImg.vectorGraphics = animal.assetOpen;
			print("Rigtigt");
			GetComponent<Animator>().SetTrigger("Correct");
		} else {
			print("Forkert");
			GetComponent<Animator>().SetTrigger("Wrong");
			tutorial.SetActive(true);
			tutorial.GetComponent<TutorialController>().Game_Shark(3);
		}
	}
		
	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Shark", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Shark");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.gameObject);
	}
}
