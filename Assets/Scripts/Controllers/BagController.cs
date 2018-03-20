using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour {

	[SerializeField] GameObject itemPrefab;
	[SerializeField] GameObject itemPrefabEmpty;
	[SerializeField] Transform itemParent;

	void Start() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");

		foreach(Item item in controller.GetComponent<ItemController>().GetItems()) {
			if (item.HasSeen) {
				GameObject itemAdd = Instantiate (itemPrefab, itemParent);
				itemAdd.GetComponent<Game_BagItem> ().Setup (item);
				itemAdd.GetComponent<Button> ().onClick.AddListener (delegate {
					PickItem (item);
				});
			} else if(item.HasSeen == false) {
				GameObject itemAdd = Instantiate (itemPrefabEmpty, itemParent);
			}
		}
	}

	void PickItem(Item item) {
		print(item.englishName + " er valgt");

		switch(item.englishName) {
		case "Feather":
			GameObject gameSealController = GameObject.FindGameObjectWithTag("InGameController");
			gameSealController.GetComponent<InGameControllerSeal> ().ChooseToothBrush ();
			CloseBag ();
			gameSealController.GetComponent<InGameControllerSeal> ().isBagOpen = false;
			break;
		case "Vertebra":
			GameObject gameSpermwhaleController = GameObject.FindGameObjectWithTag("InGameController");
			gameSpermwhaleController.GetComponent<InGameControllerSpermwhale> ().ChooseVertebra ();
			CloseBag ();
			gameSpermwhaleController.GetComponent<InGameControllerSpermwhale> ().isBagOpen = false;
			break;
		default:
			print ("Wrong item");
			break;
		}

	}

	public void CloseBag() {
		GetComponent<Animator>().SetTrigger("Close");
	}

	public void Destroy() {
		Destroy(gameObject);
	}
}
