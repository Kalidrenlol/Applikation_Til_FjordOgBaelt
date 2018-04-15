using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class InGameControllerSpermwhale : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	public GameObject btnBag;
	public Transform canvas;
	public GameObject bag;
	public GameObject bagPrefab;
	public GameObject choosenItem;
	public GameObject choosenItemPrefab;
	public GameObject puzzle;
	public GameObject pieces;
	public GameObject InitialPiece;
	public bool isBagOpen = false;
	public bool showWinning = false;
	public int correctPiecesPlaced;

	void Start () {
		correctPiecesPlaced = 0;
		pieces.SetActive (false);

		btnBag.GetComponent<Button>().onClick.AddListener(delegate {
			if(isBagOpen == false) {
				bag = Instantiate(bagPrefab, canvas);
				bag.transform.SetSiblingIndex(3);
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

	public void ChooseVertebra() {
		choosenItem = Instantiate(choosenItemPrefab, btnBag.GetComponent<Button>().transform);
	}

	public void gameSetup() {
		puzzle.transform.GetChild (0).gameObject.GetComponent<SVGImage> ().color = new Color32(255,255,255,1);
		Destroy (choosenItem);
		pieces.SetActive (true);
		puzzle.GetComponent<Image> ().color = new Color32 (255, 255, 255, 255);
		Destroy (btnBag);
		StartCoroutine (DelayedAnimation());
	}

	IEnumerator DelayedAnimation() {
		yield return new WaitForSeconds(5);
		InitialPiece.GetComponent<Animator>().SetTrigger ("animate");
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
