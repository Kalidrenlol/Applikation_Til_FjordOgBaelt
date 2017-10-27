using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroductionGreetings : MonoBehaviour {

	[SerializeField] InputField inputName;
	[SerializeField] GameObject askNameText;
	[SerializeField] Text placeholder;

	void Start () {
		askNameText.SetActive(false);
	}

	void Update () {
		if (inputName.isFocused && askNameText.activeSelf == false) {
			askNameText.SetActive(true);
			placeholder.text = "";
		}
	}
}
