using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_PlaiceColor : MonoBehaviour {

	[SerializeField] Image imgColor;
	public Image selected;
	public Color color;

	public void Setup(Color _color) {
		color = _color;
		imgColor.color = color;
		selected.gameObject.SetActive(false);
	}

	public Color Select() {
		selected.gameObject.SetActive(true);
		return color;
	}

}
