using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Seal : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;

	void Start () {
		if (GameObject.FindGameObjectWithTag ("GameController").GetComponent<ItemController> ().GetItem ("Feather").HasSeen) {
			ShowWinning ();
		}
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Seal", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Seal");
		DestroyGame ();
	}
}
