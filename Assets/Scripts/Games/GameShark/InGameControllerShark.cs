using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class InGameControllerShark : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;

	public GameObject btnBag;
	public Transform canvas;
	public GameObject bag;
	public GameObject bagPrefab;
	public GameObject choosenItem;
	public GameObject choosenItemPrefab;
	public GameObject shark;
	public SVGAsset sharkTeeth;

	public bool isBagOpen = false;
	public bool showWinning = false;

	void Start () {
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

	public void ChooseTooth () {
		choosenItem = Instantiate(choosenItemPrefab, btnBag.GetComponent<Button>().transform);
	}

	public void GameSetup ()
	{
		shark.GetComponent<SVGImage>().vectorGraphics = sharkTeeth;
		Destroy (choosenItem);
		Destroy (btnBag);
		if (showWinning == false) { 
			ShowWinning ();
			showWinning = true;
		}
	}
		
	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Shark", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Shark");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
