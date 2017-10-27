using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class Item : MonoBehaviour {

	public string englishName;
	public string danishName;
	public string info;
	public SVGAsset asset;
	public bool HasSeen;
	public bool NewDiscover = false;

	public Animal_Question question;

	public void Setup() {
		string _hasSeen = englishName + "_hasSeen";
		if (!PlayerPrefs.HasKey(_hasSeen)) {
			PlayerPrefs.SetInt(_hasSeen, 0);
			HasSeen = false;
		} else if (PlayerPrefs.GetInt(_hasSeen) == 1) {
			HasSeen = true;
		} else {
			HasSeen = false;
		}
	}

}
