using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class ItemObject : MonoBehaviour {

	Item item;
	Animator animator;

	[SerializeField] Text txtName;
	[SerializeField] SVGImage imgImage;

	void OnEnable() {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(ShowTask);
		animator = GetComponent<Animator>();
	}

	public void Setup(Item _item) {
		item = _item;
		imgImage.vectorGraphics = _item.asset;
		animator = GetComponent<Animator>();
		txtName.text = _item.danishName;

		if (_item.NewDiscover) {
			animator.SetTrigger("Discover");
		} else if (_item.HasSeen) {
			animator.SetBool("Discovered", true);
		} else {
			txtName.gameObject.SetActive(false);
			imgImage.color = Color.black;
			animator.SetBool("Discovered", false);
		}
	}

	void IsDiscovered() {
		animator.SetBool("Discovered", true);
		item.NewDiscover = false;
	}
		
	void ShowItem() {
		GameObject itemView = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemController>().itemView;
		itemView.GetComponent<AnimalView>().ShowPage(true);
		itemView.GetComponent<AnimalView>().Setup(item.GetComponent<Item>());
	}

	void ShowTask() {
		GameObject.FindGameObjectWithTag("GameController").GetComponent<ScreenController>().ShowItemView(item);
	}
}
