using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class BottomButton : MonoBehaviour {

	GameObject gameController; 
	GameObject screenController;
	public int screenNo;

	void Start () {
		gameController = GameObject.FindGameObjectWithTag("GameController");
		screenController = GameObject.FindGameObjectWithTag("ScreenController");
		GetComponent<Button>().onClick.AddListener(delegate {
			GoToPage(screenNo);
		});
		screenNo = transform.GetSiblingIndex() - 1;
	}

	public void GoToPage(int _page) {
		gameController.GetComponent<ScreenController>().GoToPage(_page);
		Navigation custom = new Navigation();
		custom.mode = Navigation.Mode.None;
		GetComponent<Button>().navigation = custom;

        if (_page == 1) {
            gameController.GetComponent<AnimalsController>().animalView.GetComponent<AnimalView>().ShowPage(false);
        }
	}


}
