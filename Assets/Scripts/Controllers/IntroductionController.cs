using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SVGImporter;

public class IntroductionController : MonoBehaviour {
	
	[SerializeField] Button nextBtn;
	[SerializeField] Text introText_1;
	[SerializeField] InputField inputNameField;
	[SerializeField] Canvas introPage;
	[SerializeField] Canvas greetingPage;
	[SerializeField] string PlayerName;
	[SerializeField] GameObject waterBobblePrefab;

	int introCounter = 1;

	void Awake() {
		nextBtn.onClick.AddListener(delegate {
			IntroUpdate();
		});
	}

	void Start() {
		introPage.gameObject.SetActive (false);
		greetingPage.gameObject.SetActive (true);

		StartCoroutine(CreateWaterBobble());

		var se = new InputField.SubmitEvent();
		se.AddListener(SubmitName);
		inputNameField.onEndEdit = se;
	}

	void IntroUpdate() {
		
		switch (introCounter) {
		case 1:
			introText_1.text = "Hej " + PlayerName + "! \nVelkommen til Fjord & Bælt!";
			introCounter += 1;
				break;
		case 2:
			introText_1.text = "I Fjord & Bælt har vi mange dyr, som alle har brug for din hjælp!\n\nSe om du kan finde dem!";
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
		yield return new WaitForSeconds(Random.Range(1f,3f));

		GameObject bobble = Instantiate(waterBobblePrefab, GameObject.FindGameObjectWithTag("Canvas").transform.Find("WaterBobbles"));
		float posx = Random.Range(0,Screen.width);
		bobble.transform.position = new Vector3(posx, 0, 0);
		bobble.GetComponent<WaterBobble>().speed = Random.Range(2, 4);
		float size = Random.Range(0.7f, 1.1f);
		bobble.transform.localScale = new Vector3(size, size, 0);
		StartCoroutine(CreateWaterBobble());
	}
}
