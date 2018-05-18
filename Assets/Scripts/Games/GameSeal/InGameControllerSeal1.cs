using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SVGImporter;

public class InGameControllerSeal1 : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;

	public GameObject AnswerB1;
	public GameObject AnswerB2;
	public GameObject AnswerB3;
	public GameObject AnswerB4;
	public Color correct1;
	public Color correct2;
	public Color wrong1;
	public Color wrong2;
	public Color normal1;
	public Color normal2;

	public int Answer;

	float timeLeft = 2.0f;
	public bool showWinning = false;

	void Start () {
		AnswerB1.GetComponent<Button>().onClick.AddListener(delegate {
			AnswerB1.GetComponent<SVGImage>().color = wrong1;
			AnswerB1.transform.GetChild(0).GetComponent<SVGImage>().color = wrong2;
			AnswerB2.GetComponent<SVGImage>().color = normal1;
			AnswerB2.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB3.GetComponent<SVGImage>().color = normal1;
			AnswerB3.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB4.GetComponent<SVGImage>().color = normal1;
			AnswerB4.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			Answer = 1;
		});

		AnswerB2.GetComponent<Button>().onClick.AddListener(delegate {
			AnswerB2.GetComponent<SVGImage>().color = correct1;
			AnswerB2.transform.GetChild(0).GetComponent<SVGImage>().color = correct2;
			AnswerB1.GetComponent<SVGImage>().color = normal1;
			AnswerB1.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB3.GetComponent<SVGImage>().color = normal1;
			AnswerB3.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB4.GetComponent<SVGImage>().color = normal1;
			AnswerB4.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			Answer = 2;
		});

		AnswerB3.GetComponent<Button>().onClick.AddListener(delegate {
			AnswerB3.GetComponent<SVGImage>().color = wrong1;
			AnswerB3.transform.GetChild(0).GetComponent<SVGImage>().color = wrong2;
			AnswerB2.GetComponent<SVGImage>().color = normal1;
			AnswerB2.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB1.GetComponent<SVGImage>().color = normal1;
			AnswerB1.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB4.GetComponent<SVGImage>().color = normal1;
			AnswerB4.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			Answer = 3;
		});

		AnswerB4.GetComponent<Button>().onClick.AddListener(delegate {
			AnswerB4.GetComponent<SVGImage>().color = wrong1;
			AnswerB4.transform.GetChild(0).GetComponent<SVGImage>().color = wrong2;
			AnswerB1.GetComponent<SVGImage>().color = normal1;
			AnswerB1.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB3.GetComponent<SVGImage>().color = normal1;
			AnswerB3.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			AnswerB2.GetComponent<SVGImage>().color = normal1;
			AnswerB2.transform.GetChild(0).GetComponent<SVGImage>().color = normal2;
			Answer = 4;
		});
	}

	private void Update () {
		if (Answer == 2 && showWinning == false) {
			timeLeft -= Time.deltaTime;

			if (timeLeft < 0) {
				ShowWinning();
				showWinning = true;
			}
		}
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

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
