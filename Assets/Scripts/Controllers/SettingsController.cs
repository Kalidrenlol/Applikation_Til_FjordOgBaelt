using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	[SerializeField] InputField ChangeName;

	void Start() {
		ChangeName.text = PlayerPrefs.GetString("Playername");
		ChangeName.onEndEdit.AddListener(delegate {
			SetPlayername(ChangeName.text);
		});
	}

	void SetPlayername(string _name) {
		PlayerPrefs.SetString("Playername", _name);
	}

}
