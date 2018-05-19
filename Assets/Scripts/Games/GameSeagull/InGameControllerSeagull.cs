using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InGameControllerSeagull : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	public int correctBirdsPlaced;
	public bool showWinning = false;
	float timeLeft = 2.0f;
	public bool GameWon = false;

	void Start () {

	}

	void Update () {

		if (correctBirdsPlaced == 3 && showWinning == false) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) {
				ShowWinning();
				showWinning = true;
			}
		}
	}

	public void UpdateProgress() {
		correctBirdsPlaced++;
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Seagull1", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Seagull1");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
