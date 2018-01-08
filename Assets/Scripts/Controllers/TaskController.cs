using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class TaskController : MonoBehaviour {

	[SerializeField] GameObject MiddleWrapper;

	[SerializeField] Text headerText;
	[SerializeField] Button backButton;
	[SerializeField] Button submitButton;
	[SerializeField] SVGImage animalImage;
	[SerializeField] Text questionText;
	[SerializeField] Transform answerParent;
	[SerializeField] GameObject answerPrefab;
	[SerializeField] Button helpButton;

	[SerializeField] GameObject resultPrefab;
	GameObject resultBox;
	ResultController resultController;

	[Header("Loader")]
	//[SerializeField] Animator LoaderAnimator;

	GameObject chosenAnswer;

	void Start() {
		backButton.onClick.AddListener(delegate {
			GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().ScreenTask.SetActive(false);
		});
		submitButton.onClick.AddListener(delegate {
			CheckAnswer();
		});
	}

	public void CheckAnswer() {
		resultBox = Instantiate(resultPrefab, transform);
		resultController = resultBox.GetComponent<ResultController>();

		resultController.resultBtn.onClick.RemoveAllListeners();
		resultBox.GetComponent<Animator>().SetBool("Hide", false);


		if (chosenAnswer.GetComponent<TaskAnswer>().isTrue) {
			resultBox.GetComponent<Animator>().SetTrigger("Correct");
			foreach(Text text in resultController.statusTextWrapper.GetComponentsInChildren<Text>()){
				text.text = "Rigtigt!";	
			}
			foreach(Text txt in resultController.achievementText.GetComponentsInChildren<Text>()) {
				txt.text = "Du har hjulpet dyret";
			}

			resultController.resultsAnimalImage.vectorGraphics = animalImage.vectorGraphics;
			resultController.resultBtn.GetComponentInChildren<Text>().text = "Sådan!";
			resultController.resultBtn.onClick.AddListener(delegate {
				//ResetAnimation();
				SetupNewAchievement();
			});
		} else {
			foreach(Text text in resultController.statusTextWrapper.GetComponentsInChildren<Text>()){
				text.text = "Forkert, desværre!";
			}
			foreach(Text txt in resultController.achievementText.GetComponentsInChildren<Text>()) {
				txt.text = "";
			}

			resultBox.GetComponent<Animator>().SetTrigger("Correct");
			resultController.resultsAnimalImage.vectorGraphics = null;

			resultController.resultBtn.GetComponentInChildren<Text>().text = "Prøv igen";
			resultController.resultBtn.onClick.AddListener(delegate {
				//ResetAnimation();
				foreach(Transform child in resultBox.transform) {
					child.gameObject.SetActive(false);
				}
				//resultBox.SetActive(false);
				ChooseAnswer(null);
			});
		}
		resultController.resultBtn.onClick.AddListener(delegate {
			Destroy(resultBox);
		});


	}

	void SetupNewAchievement() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal(headerText.text);
	}

/*	void ResetAnimation() {
		resultBox.GetComponent<Animator>().SetBool("Hide", true);
		resultBox.GetComponent<Animator>().ResetTrigger("Correct");
	}

*/	public void Setup(Animal _ani) {
		if (resultBox == null) {
		}

		//LoaderAnimator.SetTrigger("Play");
		chosenAnswer = null;
		//ResetAnimation();
		MiddleWrapper.GetComponent<Animator>().SetBool("ShowTip", false);

		animalImage.vectorGraphics = _ani.GetComponent<Animal>().assetOpen;
		animalImage.GetComponent<AnimalCloseEye> ().animalOpenEye = _ani.GetComponent<Animal> ().assetOpen;
		animalImage.GetComponent<AnimalCloseEye> ().animalClosedEye = _ani.GetComponent<Animal> ().assetClose;
		headerText.text = _ani.GetComponent<Animal>().danishName;
		questionText.text = _ani.GetComponent<Animal>().question.question;

		foreach(Transform child in answerParent.transform) {
			Destroy(child.gameObject);
		}

		foreach(Animal_Answer answ in _ani.GetComponent<Animal>().question.answers) {
			GameObject answGO = (GameObject) Instantiate(answerPrefab, answerParent);
			answGO.GetComponentInChildren<Text>().text = answ.answer;
			answGO.GetComponent<TaskAnswer>().isTrue = answ.isTrue;
			if (answ.image != null) {
				answGO.GetComponent<TaskAnswer>().image.sprite = answ.image;
			}
			answGO.GetComponent<Button>().onClick.AddListener(delegate {
				ChooseAnswer(answGO);
				CheckAnswer();
			});
		}
		
	}

	public void ChooseAnswer(GameObject _go) {
		chosenAnswer = _go;

		foreach(Transform answ in answerParent) {
			Color _color = new Color(Color.white.r, Color.white.g, Color.white.b, 100f / 255f);
			answ.GetComponentInChildren<Image>().color = _color;
		}
		if (_go != null) {
			_go.GetComponentInChildren<Image>().color = Color.blue;
		}
	}

	public void ToggleTip() {
		MiddleWrapper.GetComponent<Animator>().SetBool("ShowTip", !MiddleWrapper.GetComponent<Animator>().GetBool("ShowTip"));
		if (MiddleWrapper.GetComponent<Animator>().GetBool("ShowTip")) {
			helpButton.GetComponentInChildren<Text>().text = "Fjern tip";
		} else {
			helpButton.GetComponentInChildren<Text>().text = "Hjælp Mig";
		}
	}


}
