using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.iOS;
using System;

public class NotificationServices : MonoBehaviour {

	void Awake() {
		#if UNITY_IOS
			UnityEngine.iOS.NotificationServices.RegisterForNotifications(
			NotificationType.Alert | 
			NotificationType.Badge | 
			NotificationType.Sound);
		#endif
	}

	void Start() {

		// schedule notification to be delivered in 5 seconds
		/*var notif = new UnityEngine.iOS.LocalNotification();
		DateTime _time = new System.DateTime(2017, 2, 3, 20, 48, 00);
		notif.fireDate = _time;
		//notif.fireDate = System.DateTime.Now.AddMinutes(1);
		print(_time);
		notif.alertBody = "Hello!";
		UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);
		*/
	}

	void Update() {
		#if UNITY_IOS
			if (UnityEngine.iOS.NotificationServices.localNotificationCount > 0) {
				Debug.Log(UnityEngine.iOS.NotificationServices.localNotifications[0].alertBody);
				UnityEngine.iOS.NotificationServices.ClearLocalNotifications();
			}
		#endif
	}

	public void SetLocalNotification(DateTime _time, string _text) {
		#if UNITY_IOS
			var notif = new UnityEngine.iOS.LocalNotification();
			notif.fireDate = _time;
			notif.alertBody = _text;
			UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);
		#endif
	}
}
