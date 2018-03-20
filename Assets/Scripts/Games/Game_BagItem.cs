using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class Game_BagItem : MonoBehaviour {

	[SerializeField] SVGImage image;

	public void Setup(Item item) {
		image.vectorGraphics = item.asset;
	}
}
