using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingChange : MonoBehaviour {

	public string json;

	void Awake() {
		gameObject.GetComponent<Button>().onClick.AddListener(delegate {
			LocalizationManager.instance.LoadLocalizedText (json);
		});
	}
}
