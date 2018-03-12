using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public GameObject CameraPrefab;
	public GameObject VuforiaPrefab;

	[SerializeField] GameObject[] GamePrefabs;
	public GameObject LoadedGame;
	bool flash = false;

	void Start() {
		ShowCamera(false);
	}

	public void ShowCamera(bool _bool) {
		GetComponent<ScreenController>().ShowCamera(_bool);

		if(_bool) {
			flash = false;
			GetComponent<ScreenController>().ShowTask(false);

			if (LoadedGame) {
				Destroy(LoadedGame);
			}
		}
	}

	public void Update() {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			//GetComponent<AnimalsController>().DiscoverAnimal("Crab");
			LoadGame("Plaice");
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			LoadGame("HarbourPorpoise");
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			LoadGame("Spermwhale");
		}

		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			LoadGame("Seal");
		}

		if (Input.GetKeyDown(KeyCode.Alpha5)) {
			LoadGame("Shark");
		}

		if (Input.GetKeyDown(KeyCode.Alpha6)) {
			GetComponent<AnimalsController>().DiscoverAnimal("Starfish");
		}

		if (Input.GetKeyDown(KeyCode.Alpha7)) {
			GetComponent<AnimalsController>().DiscoverAnimal("Crab");
			GetComponent<AnimalsController>().DiscoverAnimal("Crab2");
			GetComponent<AnimalsController>().DiscoverAnimal("HarbourPorpoise");
			GetComponent<AnimalsController>().DiscoverAnimal("HarbourPorpoise2");
			GetComponent<AnimalsController>().DiscoverAnimal("Plaice");
			GetComponent<AnimalsController>().DiscoverAnimal("Killerwhale");
			GetComponent<AnimalsController>().DiscoverAnimal("SeaGull");
			GetComponent<AnimalsController>().DiscoverAnimal("Seal");
			GetComponent<AnimalsController>().DiscoverAnimal("Seal2");
			GetComponent<AnimalsController>().DiscoverAnimal("Shark");
			GetComponent<AnimalsController>().DiscoverAnimal("Spermwhale");
			GetComponent<AnimalsController>().DiscoverAnimal("Starfish");
		}

		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			GetComponent<ItemController> ().DiscoverItem ("Feather");
		}


		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			GetComponent<ItemController> ().DiscoverItem ("Anchor");
			GetComponent<ItemController> ().DiscoverItem ("BucketFish");
			GetComponent<ItemController> ().DiscoverItem ("Feather");
			GetComponent<ItemController> ().DiscoverItem ("Tooth");
			GetComponent<ItemController> ().DiscoverItem ("Vertebra");
		}
	}

	public void LoadGame(string name) {
		print("LoadGame: " + name);
		foreach(GameObject go in GamePrefabs) {
			if (go.name == "Game_"+name) {
				LoadedGame = Instantiate(go);
				break;
			}
		}
	}

	public void ShowAnimal(string _scannedTarget) {
		#if !UNITY_EDITOR

		Handheld.Vibrate();

		#endif
		Debug.Log (_scannedTarget);
		Animal animal = GetComponent<AnimalsController>().GetAnimal(_scannedTarget);

		ShowCamera(false);

		if (animal != null) {
			if (animal.HasGame) {
				LoadGame (animal.englishName);
			} else {
				GetComponent<ScreenController> ().ShowTask ();
				GetComponent<ScreenController> ().ScreenTask.GetComponent<TaskController> ().Setup (animal);		
			}
		} else {
			Item item = GetComponent<ItemController>().GetItem(_scannedTarget);
			GetComponent<ScreenController> ().ShowOpenItem(item);
		}
	}

	public bool ToggleFlash() {
		flash = !flash;
		CameraDevice.Instance.SetFlashTorchMode(flash);
		return flash;
	}
}
