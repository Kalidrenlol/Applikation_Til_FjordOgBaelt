using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class InGameControllerCrab : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	public bool GameWon = false;
	public GameObject GameEnd1;
	public GameObject GameEnd2;
	float timeLeft = 2.0f;
	public GameObject CrabModel;

  	void Start () { }

    void Update ()
	{
		if (GameWon) {
			timeLeft -= Time.deltaTime;
			GameEnd1.SetActive(false);
			GameEnd2.SetActive(false);

			if (timeLeft < 0) {
				ShowWinning();
				GameWon = false;
			}
		}
    }

    public void MoveLeft ()
	{
		CrabModel.GetComponent<InGameModelCrab>().MoveLeft();
	}

	public void MoveRight ()
	{
		CrabModel.GetComponent<InGameModelCrab>().MoveRight();
	}

	public void Rotate () {
		CrabModel.GetComponent<InGameModelCrab>().Rotate();
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Crab", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Crab");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
