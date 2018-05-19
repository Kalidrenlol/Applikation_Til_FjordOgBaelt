using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour {

	[SerializeField] GameObject itemPrefab;
	[SerializeField] GameObject itemPrefabEmpty;
	[SerializeField] Transform itemParent;
	public GameObject InGameController;

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

	void PickItem (Item item)
	{
		print (item.englishName + " er valgt");
		GameObject InGameController = GameObject.FindGameObjectWithTag ("InGameController");

		print (InGameController.transform.parent.name);

		switch (item.englishName) {
		case "Feather":
			if (InGameController.transform.parent.name == "Game_Seal2(Clone)") {
				//GameObject gameSealController = GameObject.FindGameObjectWithTag("InGameController");
				InGameController.GetComponent<InGameControllerSeal> ().ChooseToothBrush ();
				CloseBag ();
				InGameController.GetComponent<InGameControllerSeal> ().isBagOpen = false;
			} else {
				itemParent.GetChild(1).transform.GetChild(1).gameObject.SetActive(true);
			}
			break;
		case "Vertebra":
			if (InGameController.transform.parent.name == "Game_Spermwhale1(Clone)") {
				//GameObject gameSpermwhaleController = GameObject.FindGameObjectWithTag("InGameController");
				InGameController.GetComponent<InGameControllerSpermwhale> ().ChooseVertebra ();
				CloseBag ();
				InGameController.GetComponent<InGameControllerSpermwhale> ().isBagOpen = false;
			} else {
				itemParent.GetChild(3).transform.GetChild(1).gameObject.SetActive(true);
			}
			break;
		case "Tooth":
			if (InGameController.transform.parent.name == "Game_Shark(Clone)") {
				InGameController.GetComponent<InGameControllerShark> ().ChooseTooth ();
				CloseBag ();
				InGameController.GetComponent<InGameControllerShark> ().isBagOpen = false;
			} else {
				itemParent.GetChild(2).transform.GetChild(1).gameObject.SetActive(true);
			}
			break;
		case "BucketFish":
			if (InGameController.transform.parent.name == "Game_HarbourPorpose2(Clone)") {
				//InGameController.GetComponent<InGameControllerShark> ().ChooseTooth ();
				CloseBag ();
				InGameController.GetComponent<InGameControllerShark> ().isBagOpen = false;
			} else {
				itemParent.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);
			}
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
