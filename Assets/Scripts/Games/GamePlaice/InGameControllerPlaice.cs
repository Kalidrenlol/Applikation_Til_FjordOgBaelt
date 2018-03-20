using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;
using UnityEngine.SceneManagement;

public class InGameControllerPlaice : MonoBehaviour {

	public Color[] colors;
	public Color selectedColor = Color.white;
	[Range(0,3)] public int correctColorIndex;
	Color correctColor;

	[SerializeField] GameObject ColorPrefab;
	[SerializeField] Transform ColorParent;
	[SerializeField] Transform dotParent;
	[SerializeField] GameObject ShowWinningPrefab;

	void Start() {
		correctColor = colors[correctColorIndex];

		foreach(Transform child in ColorParent) {
			Destroy(child.gameObject);
		}

		foreach(Color _color in colors) {
			GameObject go = Instantiate(ColorPrefab, ColorParent);
			go.GetComponent<Game_PlaiceColor>().Setup(_color);
			go.GetComponent<Button>().onClick.AddListener(delegate {
				foreach (Transform child in ColorParent) {
					child.GetComponent<Game_PlaiceColor>().selected.gameObject.SetActive(false);
				}
				selectedColor = go.GetComponent<Game_PlaiceColor>().Select();
			});
		}

		foreach (Transform child in dotParent) {
			child.GetComponent<Button>().onClick.AddListener(delegate {
				Paint(child);
			});
		}
	}

	void Paint(Transform child) {
		child.GetChild(0).GetComponent<SVGImage>().color = GameObject.FindGameObjectWithTag("InGameController").GetComponent<InGameControllerPlaice>().selectedColor;
		if (EverythingPainted()) {
			if (EverythingCorrect()
			) {
				GameObject.FindGameObjectWithTag("InGameController").transform.parent.GetComponent<Animator>().SetTrigger("Correct");
				ShowWinning ();
			} else {
				Debug.Log ("Wrong");
			}
		}
	}

	bool EverythingCorrect() {
		foreach(Transform child in dotParent) {
			if (child.GetChild(0).GetComponent<SVGImage>().color != correctColor) {
				return false;
			}
		}
		return true;
	}

	bool EverythingPainted() {
		foreach(Transform child in dotParent) {
			if (child.GetChild(0).GetComponent<SVGImage>().color == Color.white) {
				return false;
			}
		}
		return true;
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Plaice", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Plaice");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
