﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameControllerPorpoise2 : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;

	void Start () {
		if (GameObject.FindGameObjectWithTag ("GameController").GetComponent<ItemController> ().GetItem ("BucketFish").HasSeen) {
			ShowWinning ();
		}
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("HarbourPorpoise2", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("HarbourPorpoise2");
		DestroyGame ();
	}
}