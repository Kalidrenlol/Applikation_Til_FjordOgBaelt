using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SVGImporter;

public class IntroductionController : MonoBehaviour {
	
	[SerializeField] Button nextBtn;
	[SerializeField] Text introText_1;
	[SerializeField] Text welcomeText;
	[SerializeField] Text welcomeSignText;
	[SerializeField] InputField inputNameField;
	[SerializeField] Canvas introPage;
	[SerializeField] Canvas greetingPage;
	[SerializeField] Canvas languagePage;
	[SerializeField] string PlayerName;
	[SerializeField] GameObject waterBobblePrefab;

	int introCounter = 1;
	public int bobbleCounter = 0;

	void Awake() {
		nextBtn.onClick.AddListener(delegate {
			IntroUpdate();
		});
	}

	void Start() {
		introPage.gameObject.SetActive (false);
		greetingPage.gameObject.SetActive (false);
		languagePage.gameObject.SetActive (true);

		var se = new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		inputNameField.onEndEdit = se;
	}

	void IntroUpdate() {
		switch (introCounter) {
		case 1:
			introText_1.text = LocalizationManager.instance.GetLocalizedValue("introduction_hello") + PlayerName + LocalizationManager.instance.GetLocalizedValue("introduction_intro1");
			introCounter += 1;
				break;
		case 2:
			introText_1.text = LocalizationManager.instance.GetLocalizedValue("introduction_intro2");
			introCounter += 1;
				break;
		case 3:
			SceneManager.LoadScene("Main");
			break;
		}
	}

	private void SubmitName(string input)
	{
		PlayerName = input;
		PlayerPrefs.SetString("Playername", PlayerName);
		greetingPage.gameObject.SetActive (false);
		introPage.gameObject.SetActive (true);
		IntroUpdate();
	}

	IEnumerator CreateWaterBobble() {
		yield return new WaitForSeconds (Random.Range (2f, 5f));
		GameObject bobble = Instantiate (waterBobblePrefab, GameObject.FindGameObjectWithTag ("Canvas").transform.Find ("WaterBobbles"));
		float posx = Random.Range (0, Screen.width);
		bobble.transform.position = new Vector3 (posx, 0, 0);
		float size = Random.Range (0.7f, 1.1f);
		bobble.transform.localScale = new Vector3 (size, size, 0);
		StartCoroutine (CreateWaterBobble ());
	}

	public void LoadLanguage(string json) {
		LocalizationManager.instance.LoadLocalizedText (json);
		welcomeText.text = LocalizationManager.instance.GetLocalizedValue ("introduction_welcome");
		welcomeSignText.text = LocalizationManager.instance.GetLocalizedValue ("introduction_press");
		greetingPage.gameObject.SetActive (true);
		languagePage.gameObject.SetActive (false);
		StartCoroutine(CreateWaterBobble());
	}
}
