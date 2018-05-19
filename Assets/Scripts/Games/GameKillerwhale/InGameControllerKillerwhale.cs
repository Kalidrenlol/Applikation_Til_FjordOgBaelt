using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InGameControllerKillerwhale : MonoBehaviour {

	public GameObject guessBtn;
	public GameObject plusBtn;
	public GameObject minusBtn;
	public int gameState;
	public GameObject kwSmall;
	public GameObject kwMedium;
	public GameObject kwLarge;
	public bool showWinning = false;
	[SerializeField] GameObject ShowWinningPrefab;

	void Start () {
		int gameState = 0;

		guessBtn.GetComponent<Button>().onClick.AddListener(delegate {
			CheckIfCorrect();
		});

		plusBtn.GetComponent<Button>().onClick.AddListener(delegate {
			ChangeSize("plus");
		});

		minusBtn.GetComponent<Button>().onClick.AddListener(delegate {
			ChangeSize("minus");
		});
	}

	void Update () {
		
	}

	public void CheckIfCorrect ()
	{
		if (gameState == 1 && showWinning == false) {
			ShowWinning();
			showWinning = true;
		}
	} 

	public void ChangeSize (string value)
	{
		if (gameState == 0 && value == "plus") {
			kwMedium.SetActive(false);
			kwLarge.SetActive(true);
			gameState++;
			plusBtn.SetActive(false);
		} else if(gameState == 0 && value == "minus") {
			kwMedium.SetActive(false);
			kwSmall.SetActive(true);
			gameState--;
			minusBtn.SetActive(false);
		} else if(gameState == -1 && value == "plus") {
			kwMedium.SetActive(true);
			kwSmall.SetActive(false);
			gameState++;
			minusBtn.SetActive(true);
		} else if(gameState == 1 && value == "minus") {
			kwMedium.SetActive(true);
			kwLarge.SetActive(false);
			gameState--;
			plusBtn.SetActive(true);
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
