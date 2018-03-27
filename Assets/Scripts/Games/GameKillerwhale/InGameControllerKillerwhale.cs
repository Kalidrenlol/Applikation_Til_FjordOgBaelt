using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InGameControllerKillerwhale : MonoBehaviour {

	public GameObject slider;
	public GameObject guessBtn;
	[SerializeField] GameObject ShowWinningPrefab;

	void Start () {

		guessBtn.GetComponent<Button>().onClick.AddListener(delegate {
			CheckIfCorrect();
		});
	}

	void Update () {
		print (slider.GetComponent<Slider>().value);
	}

	public void CheckIfCorrect ()
	{
		if (slider.GetComponent<Slider> ().value == 4) {
			ShowWinning ();
		} else {
			print("WRONG");
		}
	} 

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Killerwhale", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Killerwhale");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
