using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class Game_BagGO : MonoBehaviour {

	public Item item;
	public SVGImage img;

	public void Destroy() {
		GameObject.FindGameObjectWithTag("InGameController").GetComponent<InGameController>().GiveItemToAnimal(item);
		Destroy(gameObject);
	}
}
