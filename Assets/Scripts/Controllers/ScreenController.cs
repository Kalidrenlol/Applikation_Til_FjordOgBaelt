﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using UnityEngine.SceneManagement;
using SVGImporter;

public class ScreenController : MonoBehaviour {

	[SerializeField] GameObject TutorialPrefab;

	[Header("Pages")]
	public GameObject TopBar;
	[SerializeField] GameObject HorizontalScrollGO;
	public GameObject ScreenPrize;
	public GameObject ScreenSettings;
	public GameObject ScreenTask;
	[SerializeField] GameObject ItemOpenPrefab;
	[SerializeField] GameObject ScreenAnimal;
	[SerializeField] GameObject GameUI;
	[SerializeField] GameObject CameraUI;

	[Header("Others")]
	public GameObject ShowWinningPrefab;
	public SVGImage iconTrophy;

	 public HorizontalScrollSnap MenuObject;
	[HideInInspector] public GameObject tutorialGO;

	[Header("Color Block")]
	public ColorBlock standardColorBlock;


	void Awake() {
		tutorialGO = (GameObject) Instantiate(TutorialPrefab, GameObject.FindGameObjectWithTag("Canvas").transform);

		if (PlayerPrefs.GetInt("ShowTutorial") != 0) {
			tutorialGO.SetActive(false);
		}
	}

	void Start() {
		DeactivateAll();
		MenuObject = HorizontalScrollGO.GetComponent<HorizontalScrollSnap>();
		ShowHorizontalScrollSnap();
		CheckCurrentPage();
	}

	public void ShowHorizontalScrollSnap() {
		DeactivateAll();
		HorizontalScrollGO.SetActive(true);
	}

	public void GoToPage(int _index) {
		ScreenAnimal.GetComponent<AnimalView>().ShowPage(false);
		//ShowHorizontalScrollSnap();
		MenuObject.GoToScreen(_index);
		CheckCurrentPage();
	}

	public void ShowPrize(bool _bool) {
		TopBar.GetComponent<Animator>().SetBool("Show", !_bool);
		ScreenPrize.GetComponent<Animator>().SetBool("Show", _bool);

		if (ScreenPrize.GetComponent<Animator>().GetBool("Show") == true) {
			int count = GetComponent<AnimalsController>().GetAnimalSeen();
			ScreenPrize.GetComponent<PrizeController>().Setup(count);
			AllAnimalsSeen(true);
		}
	}

	public void AllAnimalsSeen(bool _bool) {
		if (_bool) {
			iconTrophy.color = Color.black;
		} else {
			iconTrophy.color = Color.white;
		}
	}

	public void ShowSettings(bool _bool) {
		TopBar.GetComponent<Animator>().SetBool("Show", !_bool);
		ScreenSettings.GetComponent<Animator>().SetBool("Show", _bool);
	}

	public void ShowTask() {
		//ScreenPrize.SetActive(false);
		//ScreenSettings.SetActive(false);
		ScreenTask.SetActive(true);
	}

	public void ShowTask(bool _bool) {
		ScreenTask.SetActive(_bool);
	}

	public void ShowOpenItem(Item _item) {
		GameObject itemOpen = Instantiate(ItemOpenPrefab, GameUI.transform);
		itemOpen.GetComponent<OpenItemController>().Setup(_item);
	}

	public void ScanAnimal(Animal animal) {
		ScreenTask.GetComponent<TaskController>().Setup(animal);
		ShowTask();
	}

	public void ShowAnimalView(Animal animal) {
		ScreenAnimal.GetComponent<AnimalView>().Setup(animal);
	}

	public void ShowItemView(Item item) {
		ScreenAnimal.GetComponent<AnimalView>().Setup(item);
	}

	public void ShowCamera(bool _bool) {
		GetComponent<GameController>().CameraPrefab.SetActive(!_bool);
		GetComponent<GameController>().VuforiaPrefab.SetActive(_bool);
		Debug.Log("ShowCamera");
		GameUI.SetActive(!_bool);
		CameraUI.SetActive(_bool);
	}

	public string CheckCurrentPage() {
		//ColorBlock _customBlock = standardColorBlock;
		//_customBlock.normalColor = standardColorBlock.pressedColor;

		if (ScreenPrize.GetComponent<Animator>().GetBool("Show")) {
			return "Prize";
		} else if (ScreenSettings.GetComponent<Animator>().GetBool("Show")) {
			return "Settings";
		} else {
			return "Page";
		}
	}

	public void GoToScene(string _scenename) {
		SceneManager.LoadScene(_scenename);
	}
	void DeactivateAll() {
		ScreenPrize.GetComponent<Animator>().SetBool("Show", false);
		ScreenSettings.GetComponent<Animator>().SetBool("Show", false);
		ScreenTask.SetActive(false);
		HorizontalScrollGO.SetActive(false);
	}

}
