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

	void Awake() {
		
	}

	void Start() {
		ShowCamera(false);
		Debug.Log ("LOL");
	}

	public void ShowCamera(bool _bool) {
		GetComponent<ScreenController>().ShowCamera(_bool);
		Debug.Log ("asdasd");

		if(_bool) {
			flash = false;
			GetComponent<ScreenController>().ShowTask(false);
			if (LoadedGame) {
				Destroy(LoadedGame);
			}
		}
	}

	public void Update() {
		/*if (Input.GetKeyDown(KeyCode.U)) {
			ShowAnimal("Shark");
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			ShowAnimal("Vertebra");
		}

		if (Input.GetKeyDown(KeyCode.H)) {
			ShowAnimal("Tooth");
		}

		if (Input.GetKeyDown(KeyCode.J)) {
			ShowAnimal("Feather");
		}

		if (Input.GetKeyDown(KeyCode.K)) {
			ShowAnimal("BucketFish");
		}

		if (Input.GetKeyDown(KeyCode.L)) {
			ShowAnimal("Anchor");
		}

		if (Input.GetKeyDown(KeyCode.R)) {
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
			GetComponent<AnimalsController>().DiscoverAnimal("Starfish2");
		}*/
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
