using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InGameControllerSeagull : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	public int correctBirdsPlaced;
	public bool showWinning = false;

	void Start () {

	}

	void Update () {
		if (correctBirdsPlaced == 3 && showWinning == false) {
			ShowWinning ();
			showWinning = true;
		}
	}

	public void UpdateProgress() {
		correctBirdsPlaced++;
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Seagull", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Seagull");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
