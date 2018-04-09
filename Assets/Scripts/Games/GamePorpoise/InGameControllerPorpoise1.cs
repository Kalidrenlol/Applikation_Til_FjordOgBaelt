using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameControllerPorpoise1 : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	public GameObject Selection1;
	public GameObject Selection2;
	public GameObject Selection3;
	public GameObject AnswerButton;
	public GameObject Picture;

	public bool CorrectAnswer = false; 
	public bool showWinning = false;

	void Start () {
		Selection1.GetComponent<Button>().onClick.AddListener(delegate {
			ChangePicture("1");
		});	

		Selection2.GetComponent<Button>().onClick.AddListener(delegate {
			ChangePicture("2");
		});	

		Selection3.GetComponent<Button>().onClick.AddListener(delegate {
			ChangePicture("3");
		});	

		AnswerButton.GetComponent<Button>().onClick.AddListener(delegate {
			CheckAnswer();
		});	
	}

	public void ChangePicture(string type) {
		switch(type) {
			case "1":
				Picture.GetComponent<Image>().sprite = Selection1.GetComponent<Image>().sprite;
				CorrectAnswer = false; 
				break;
			case "2":
				Picture.GetComponent<Image>().sprite = Selection2.GetComponent<Image>().sprite;
				CorrectAnswer = true; 
				break;
			case "3":		
				Picture.GetComponent<Image>().sprite = Selection3.GetComponent<Image>().sprite;
				CorrectAnswer = false; 
				break;
			default:
				print ("Error");
				break;
		}
	}

	public void CheckAnswer ()
	{
		if (CorrectAnswer == true && showWinning == false) {
			ShowWinning();
			showWinning = true;
		}
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("HarbourPorpoise", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("HarbourPorpoise");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}

}
