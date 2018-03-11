using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LocalizationManager : MonoBehaviour {

	public static LocalizationManager instance;

	private Dictionary<string, string> localizedText;
	private bool isReady = false;
	private string missingTextString = "Localized text not found";
	private string filePath;
	private string dataAsJson;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}

	public void LoadLocalizedText(string fileName) {
		localizedText = new Dictionary<string, string> ();
		filePath = Path.Combine(Application.streamingAssetsPath + "/", fileName);
		#if UNITY_EDITOR
			Debug.Log("Unity Editor");
			
			dataAsJson= File.ReadAllText (filePath);
		#endif

		#if UNITY_IPHONE
			Debug.Log("Iphone");
		#endif

		#if UNITY_IOS
			Debug.Log("IOS");
		#endif

		#if UNITY_ANDROID
			Debug.Log("Android");
			WWW reader = new WWW (filePath);
			while (!reader.isDone) {}
			dataAsJson = reader.text;
		#endif

		Debug.Log (filePath);

		LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

		for (int i = 0; i < loadedData.items.Length; i++) {
			localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);   
		}

		if (File.Exists (filePath)) {
			 


			Debug.Log ("Data loaded, dictionary contains: " + localizedText.Count + " entries");
		} else {
			Debug.LogError ("Cannot find file!");
		}

		isReady = true;
	}

	public string GetLocalizedValue(string key) {
		string result = missingTextString;
		if (localizedText.ContainsKey (key)) 
		{
			result = localizedText [key];
		}
		return result;
	}

	public bool GetIsReady() {
		return isReady;
	}
}
