using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	[SerializeField] InputField ChangeName;

	[SerializeField] InputField Code;
	[SerializeField] Button DebugButton;

	public GameObject[] DebugAnimal;
	public GameObject Content;
	public GameObject Controller;

	void Start() {
		ChangeName.text = PlayerPrefs.GetString("Playername");
		ChangeName.onEndEdit.AddListener(delegate {
			SetPlayername(ChangeName.text);
		});

		DebugButton.onClick.AddListener(delegate {
			if(Code.text == "ttek") {
				Content.SetActive(true);
			}
		});

		DebugAnimal[0].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Crab");
		});

		DebugAnimal[1].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Starfish2");
		});

		DebugAnimal[2].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("HarbourPorpoise");
		});

		DebugAnimal[3].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("HarbourPorpoise2");
		});

		DebugAnimal[4].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Plaice");
		});

		DebugAnimal[5].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Killerwhale");
		});	

		DebugAnimal[6].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Seagull1");
		});

		DebugAnimal[7].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Seal");
		});

		DebugAnimal[8].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Seal2");
		});

		DebugAnimal[9].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Shark");
		});

		DebugAnimal[10].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Spermwhale1");
		});

		DebugAnimal[11].GetComponent<Button>().onClick.AddListener(delegate {
			Controller.GetComponent<ScreenController> ().ShowSettings(false);
			Controller.GetComponent<AnimalsController> ().DiscoverAnimal ("Starfish");
		});
	}

	void SetPlayername(string _name) {
		PlayerPrefs.SetString("Playername", _name);
	}

}
