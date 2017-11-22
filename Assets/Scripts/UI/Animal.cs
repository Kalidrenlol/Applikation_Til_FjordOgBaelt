using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class Animal : MonoBehaviour {

	public string danishName;
	public string englishName;
	public SVGAsset assetOpen;
	public SVGAsset assetClose;
	public bool HasSeen;
	public int seenIndex = 0;
	public bool NewDiscover = false;

	[Tooltip("Hvis der er et spil til dyret, kryds af")]
	public bool HasGame;
	public string itemNeeded;
	public Animal_Question question;

	public void Setup() {
		string _hasSeen = danishName + "_hasSeen";
		string _seenIndex = "A_" + englishName + "_seenIndex";

		if (!PlayerPrefs.HasKey(_hasSeen)) {
			PlayerPrefs.SetInt(_hasSeen, 0);
			PlayerPrefs.SetInt(_seenIndex, 0);
			HasSeen = false;	
		} 
		else if (PlayerPrefs.GetInt(_hasSeen) == 1) {
			HasSeen = true;
		}
		else {
			HasSeen = false;
		}
		seenIndex = PlayerPrefs.GetInt (_seenIndex);
	}
}
