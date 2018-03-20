using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameControllerSpermwhale : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	public Button btnBag;
	public Transform canvas;
	public GameObject bag;
	public GameObject bagPrefab;
	public bool isBagOpen = false;
	public bool showWinning = false;
	public int correctPiecesPlaced;

	void Start () {
		correctPiecesPlaced = 0;

		btnBag.onClick.AddListener(delegate {
			if(isBagOpen == false) {
				bag = Instantiate(bagPrefab, canvas);
				bag.transform.SetSiblingIndex(4);
				isBagOpen = true;
			} 
			else if(isBagOpen == true) {
				bag.GetComponent<BagController>().CloseBag();
				isBagOpen = false;
			}
		});	
	}

	void Update() {
		if (correctPiecesPlaced == 9 && showWinning == false) {
			ShowWinning ();
			showWinning = true;
		}
	}

	public void UpdateProgress() {
		correctPiecesPlaced++;
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
		
	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Spermwhale", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Spermwhale");
		DestroyGame ();
	}
}
