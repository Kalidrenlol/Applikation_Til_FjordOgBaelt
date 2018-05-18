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

	public void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ShowAnimal ("Crab");
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ShowAnimal ("Starfish");
		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ShowAnimal ("Starfish2");
		}

		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			ShowAnimal ("HarbourPorpoise");
		}

		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ShowAnimal ("HarbourPorpoise2");
		}

		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			ShowAnimal ("Plaice");
		}

		if (Input.GetKeyDown (KeyCode.Alpha7)) {
			ShowAnimal ("Killerwhale");
		}

		if (Input.GetKeyDown (KeyCode.Alpha8)) {
			ShowAnimal ("SeaGull");
		}

		if (Input.GetKeyDown (KeyCode.Alpha9)) {
			ShowAnimal ("Seal");
		}

		if (Input.GetKeyDown (KeyCode.Alpha0)) {
			ShowAnimal ("Seal2");
		}

		if (Input.GetKeyDown (KeyCode.O)) {
			ShowAnimal ("Shark");
		}

		if (Input.GetKeyDown (KeyCode.P)) {
			ShowAnimal ("Spermwhale");
		}

		if (Input.GetKeyDown (KeyCode.Q)) {
			GetComponent<ItemController> ().DiscoverItem ("BucketFish");
			GetComponent<ItemController> ().DiscoverItem ("Feather");
			GetComponent<ItemController> ().DiscoverItem ("Tooth");
			GetComponent<ItemController> ().DiscoverItem ("Vertebra");
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			GetComponent<AnimalsController> ().DiscoverAnimal ("Crab");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Starfish2");
			GetComponent<AnimalsController> ().DiscoverAnimal ("HarbourPorpoise");
			GetComponent<AnimalsController> ().DiscoverAnimal ("HarbourPorpoise2");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Plaice");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Killerwhale");
			GetComponent<AnimalsController> ().DiscoverAnimal ("SeaGull");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Seal");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Seal2");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Shark");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Spermwhale");
			GetComponent<AnimalsController> ().DiscoverAnimal ("Starfish");
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
