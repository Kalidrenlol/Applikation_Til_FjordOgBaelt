using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class LocalizationManager : MonoBehaviour {

	public static LocalizationManager instance;

	private Dictionary<string, string> localizedText;
	private bool isReady = false;
	private string missingTextString = "Localized text not found";
	private string filePath;
    private JsonData jsonTest;
    
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

		/*#if UNITY_IPHONE
			Debug.Log("Iphone");
			filePath =  Application.dataPath + "/Raw/" + filename;
		Debug.Log("Android");
		WWW reader = new WWW (filePath);
		while (!reader.isDone) {}
		dataAsJson = reader.text;
		#endif*/

		#if UNITY_IOS
			Debug.Log("IOS");
            filePath = Application.dataPath + "/Raw/" + fileName;
            jsonTest = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Raw/" + fileName));
        for (int i = 0; i < jsonTest[0].Count; i++) {
            print("KIG HER: --- " + jsonTest[0][i]["key"]);
            print("KIG HER: --- " + jsonTest[0][i]["value"]);
        }
            
            Debug.Log("Fil fundet: " + filePath);
			WWW reader = new WWW (filePath);
			while (!reader.isDone) {}
        print("1");
			dataAsJson = reader.text;
        print(reader.text);
        print("2");
		#endif

		#if UNITY_ANDROID
			Debug.Log("Android");
			WWW reader = new WWW (filePath);
			while (!reader.isDone) {}
			dataAsJson = reader.text;
		#endif

		Debug.Log (filePath);
        print("3");

		LocalizationData loadedData = JsonUtility.FromJson<LocalizationData> (dataAsJson);

		/*for (int i = 0; i < loadedData.items.Length; i++) {
			localizedText.Add (loadedData.items [i].key, loadedData.items [i].value);   
		}*/
		for (int i = 0; i < jsonTest[0].Count; i++) {
			localizedText.Add (jsonTest[0][i]["key"].ToString(), jsonTest[0][i]["value"].ToString());   
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
