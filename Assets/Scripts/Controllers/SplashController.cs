using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SVGImporter;

public class SplashController : MonoBehaviour {

	[SerializeField] SVGImage splashLogo;
	[SerializeField] Text splashText;

	bool isNewPlayer;

	void Start () {
		SetDefaultLogo();
		CheckPlayer();
		FadeInImage();

		if (PlayerPrefs.GetInt("ShowTutorial") != 0) {
			print("Er færdig med tutorial");
		} else {
			print("Viser tutorial");
		}
	}

	void CheckPlayer() {
		if (PlayerPrefs.HasKey("Playername")) {
			isNewPlayer = false;
			print("Gammel spiller");
		} else {
			isNewPlayer = true;
			PlayerPrefs.SetInt("ShowTutorial", 0);
			print("Ny spiller");
		}

		StartCoroutine(MoveToNextScene());
	}

	IEnumerator MoveToNextScene() {
		yield return new WaitForSeconds(2f);

		FadeOutImage();

		yield return new WaitForSeconds(1f);

		if (isNewPlayer) {
			SceneManager.LoadScene("Introduction");
		} else {
			SceneManager.LoadScene("Main");
		}
	}

	void SetDefaultLogo() {
		splashLogo.color = new Color(splashLogo.color.r, splashLogo.color.g, splashLogo.color.b, 0f);
		splashText.color = new Color(splashText.color.r, splashText.color.g, splashText.color.b, 0f);
	}

	void FadeInImage() {
		StartCoroutine(FadeUI(splashText, 1f, 1f));
		StartCoroutine(FadeUI(splashLogo, 1f, 1f));
	}

	void FadeOutImage() {
		StartCoroutine(FadeUI(splashText, 0f, 1f));
		StartCoroutine(FadeUI(splashLogo, 0f, 1f));
	}

	IEnumerator FadeUI(Text text, float target, float duration) {
		float totalChange = target - text.color.a;
		float changePerSecond = totalChange / duration;
		float totalTime = 0;
		while (totalTime < duration) {
			totalTime += Time.deltaTime;
			float increment = Time.deltaTime * changePerSecond;
			text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + increment);

			yield return new WaitForEndOfFrame(); 
		}

		text.color = new Color(text.color.r, text.color.g, text.color.b, target);

		yield break;
	}

	IEnumerator FadeUI(SVGImage image, float target, float duration) {
		float totalChange = target - image.color.a;
		float changePerSecond = totalChange / duration;
		float totalTime = 0;
		while (totalTime < duration) {
			totalTime += Time.deltaTime;
			float increment = Time.deltaTime * changePerSecond;
			image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + increment);

			yield return new WaitForEndOfFrame(); 
		}

		image.color = new Color(image.color.r, image.color.g, image.color.b, target);

		yield break;
	}
}
