using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class Game_BagItem : MonoBehaviour {

	[SerializeField] SVGImage image;
	[SerializeField] Text upperTxt;
	[SerializeField] Text lowerTxt;

	public void Setup(Item item) {
		image.vectorGraphics = item.asset;
		upperTxt.text = item.danishName;
		lowerTxt.text = item.info;
	}

}
