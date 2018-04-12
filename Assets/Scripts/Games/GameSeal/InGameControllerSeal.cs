using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class InGameControllerSeal : MonoBehaviour {

	public GameObject ToothBrush;
	public GameObject BrushBubbles;
	public GameObject SealClosed;
	public GameObject SealOpen;
	public Button btnBag;
	public Transform canvas;
	public GameObject bag;
	public GameObject bagPrefab;
	public SVGImage ToothBrushPaste;
	public bool dragging = false;
	public bool showWinning = false;
	public bool isBagOpen = false;
	public int teethBrushed;
	public GameObject ShowWinningPrefab;

	void Start () {
		teethBrushed = 0;
		ToothBrush.SetActive (false);

		ToothBrush.GetComponent<Button>().onClick.AddListener(() => {
			ToothBrush.GetComponent<SVGImage>().vectorGraphics = ToothBrushPaste.vectorGraphics;
			dragging = true;
			ToothBrush.GetComponent<Button>().onClick.RemoveAllListeners();
		});

		SealClosed.GetComponent<Button> ().onClick.AddListener (() => {
			SealClosed.SetActive(false);
			SealOpen.SetActive(true);
		});
			
		btnBag.onClick.AddListener(delegate {
			if(isBagOpen == false) {
				bag = Instantiate(bagPrefab, canvas);
				bag.transform.SetSiblingIndex(5);
				isBagOpen = true;
			} 
			else if(isBagOpen == true) {
				bag.GetComponent<BagController>().CloseBag();
				isBagOpen = false;
			}
		});
	}

	void Update () {
		foreach (Touch touch in Input.touches) {
			/*if (touch.phase == TouchPhase.Began) { Debug.Log ("Began"); }
			if (touch.phase == TouchPhase.Ended) { Debug.Log ("Ended");; }
			if (touch.phase == TouchPhase.Stationary) { Debug.Log ("Stationary");}
			if (touch.phase == TouchPhase.Canceled) { Debug.Log ("Canceled");}*/

			if (dragging) {
				ToothBrush.gameObject.transform.position = new Vector3(touch.position.x, touch.position.y);

				if(touch.position.x > Screen.width/2) {
					ToothBrush.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
				} else {
					ToothBrush.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
				}
			}
		}

		if (teethBrushed == 32 && showWinning == false) {
			ShowWinning ();
			showWinning = true;
		}
	}

	public void UpdateProgress() {
		teethBrushed++;
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Seal2", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Seal2");
		DestroyGame ();
	}

	public void StopBrushBobbles() {
		BrushBubbles.GetComponent<ParticleSystem> ().Stop (false, ParticleSystemStopBehavior.StopEmitting);
	}

	public void StartBrushBobbles() {
		BrushBubbles.GetComponent<ParticleSystem> ().Play (false);
	}

	public void ChooseToothBrush() {
		ToothBrush.SetActive (true);
		StopBrushBobbles ();
	}
}
