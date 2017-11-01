using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class OpenItemController : MonoBehaviour {

	Item item;
	public Button treasureClosedBtn;
	public Button backButton;
	public SVGImage treasureOpen;
	public SVGImage itemImage;
	public Text text;
	public GameObject touchArea;
	public SVGImage backgroundSunshine;

	void OnEnable () {
		treasureClosedBtn.onClick.AddListener (delegate {
			openTreasure ();
		});

		backButton.onClick.AddListener(delegate {
			gameObject.SetActive(false);
		});

	}

	public void Setup(Item _item) {
		text.text = "Åbn kisten og se hvad du har fundet!";
		itemImage.vectorGraphics = _item.asset;
		itemImage.gameObject.SetActive(false);
		item = _item;
		touchArea.SetActive(false);
		treasureOpen.gameObject.SetActive(false);
		treasureClosedBtn.gameObject.SetActive(true);
		GetComponent<Animator>().SetBool("Show", false);
	}

	void openTreasure() {
		treasureClosedBtn.gameObject.SetActive (false);
		treasureOpen.gameObject.SetActive (true);
		GetComponent<Animator>().SetBool("Show", true);
		itemImage.gameObject.SetActive(true);
		text.text = "Du fandt en " + item.danishName.ToLower();
		touchArea.SetActive(true);
		touchArea.GetComponent<Button>().onClick.RemoveAllListeners();
		touchArea.GetComponent<Button>().onClick.AddListener(delegate {
			GameObject controller = GameObject.FindGameObjectWithTag("GameController");
			controller.GetComponent<ItemController>().DiscoverItem(item);
			controller.GetComponent<ScreenController>().GoToPage(2);
			gameObject.SetActive(false);
		});
	}
}
