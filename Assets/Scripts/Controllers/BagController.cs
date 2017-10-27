using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagController : MonoBehaviour {

	[SerializeField] GameObject itemPrefab;
	[SerializeField] Transform itemParent;
	[SerializeField] Button noTouchBtn;
	[SerializeField] Button closeBtn;
	public Animal animal;

	void Start() {
		foreach(Transform child in itemParent) {
			Destroy(child.gameObject);
		}

		GameObject controller = GameObject.FindGameObjectWithTag("GameController");

		foreach(Item item in controller.GetComponent<ItemController>().GetItems()) {
			if (item.HasSeen) {
				GameObject itemGO = Instantiate(itemPrefab, itemParent);
				itemGO.GetComponent<Game_BagItem>().Setup(item);
				itemGO.GetComponent<Button>().onClick.AddListener(delegate {
					PickItem(item);
				});
			}
		}

		noTouchBtn.onClick.AddListener(CloseBag);
		closeBtn.onClick.AddListener(CloseBag);
	}

	void PickItem(Item item) {
		print(item.danishName + " er valgt");

		GameObject inGameController = GameObject.FindGameObjectWithTag("InGameController");
		inGameController.GetComponent<InGameController>().GetItem(item);

		switch(animal.englishName) {
		case "Shark":
			//inGameController.GetComponent<InGameController>().GiveItemToAnimal(item);
			break;
		default:
			Debug.LogError("Wrong name");
			break;
		}
		Destroy();
	}

	public void CloseBag() {
		GetComponent<Animator>().SetTrigger("Close");
	}

	public void Destroy() {
		Destroy(gameObject);
	}
}
