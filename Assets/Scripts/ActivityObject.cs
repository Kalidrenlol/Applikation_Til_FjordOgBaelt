using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ActivityObject : MonoBehaviour {

	[SerializeField] Text txtTime;
	[SerializeField] Text txtText;
	[SerializeField] bool isSet;
	[SerializeField] GameObject toggle;

	[SerializeField] int debugTime;
	[SerializeField] int debugMinute;

	DateTime dateTime;

	void Start() {
		dateTime = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month , DateTime.Now.Day , debugTime , debugMinute, 0);
		Setup(dateTime, txtText.ToString(), isSet);
	}

	void Setup(DateTime _dateTime, string _text, bool _isSet) {
		txtText.text = _text;
		isSet = _isSet;

		toggle.GetComponent<Toggle>().isOn = isSet;
	}

	public void Toggle() {
		isSet = toggle.GetComponent<Toggle>().isOn;

		if (isSet) {
			GameObject.FindGameObjectWithTag("GameController").GetComponent<NotificationServices>().SetLocalNotification(System.DateTime.Now.AddSeconds(3), "Søløverne bliver fodret om 10 minutter!");
		}
	}

}
