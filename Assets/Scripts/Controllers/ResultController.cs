using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class ResultController : MonoBehaviour {

	public GameObject statusTextWrapper;
	public Button resultBtn;
	public GameObject achievementWrapper;
	public GameObject achievementText;
	public SVGImage resultsAnimalImage;

	public void Setup(string _name, bool _correct) {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		Animal ani = controller.GetComponent<AnimalsController>().GetAnimal(_name);
		resultsAnimalImage.vectorGraphics = ani.assetOpen;
		print(_name);

		if (_correct) {
			GetComponent<Animator>().SetTrigger("Correct");
		}

		if(_name == "Spermwhale1") {
			achievementText.GetComponent<Text>().text = "Kig op på kaskelotskeletter og se hvor mange ryghvirvler rygsøjlen består af!";
		} else if(_name == "Starfish") {
			achievementText.GetComponent<Text>().text = "Både søstjernen og krabben kan miste et ben og leve videre!";
		}  else if(_name == "Starfish2") {
			achievementText.GetComponent<Text>().text = "Prøv at finde en søstjerne i rørebassinet og se om du kan se pletten!";
		}  else if(_name == "Seal2") {
			achievementText.GetComponent<Text>().text = "De tre voksne sæler i fjord og bælt hedder Naja, Tulle og Svante!";
		}  else if(_name == "Seal") {
			achievementText.GetComponent<Text>().text = "Sælenes spidse tænder minder meget om ulvens eller en stor hunds tænder!";
		}  else if(_name == "Seagull1") {
			achievementText.GetComponent<Text>().text = "Der er tam måge der kommer på Fjord og bælt dens navner Andy!";
		}  else if(_name == "HarbourPorpoise2") {
			achievementText.GetComponent<Text>().text = "Marsvin og sæler er pattedyr og har derfor navler som os mennesker!";
		}  else if(_name == "HarbourPorpoise") {
			achievementText.GetComponent<Text>().text = "Kig på skærmen for at se hvordan marsvinets biosonar virker!";
		}  else if(_name == "Plaice") {
			achievementText.GetComponent<Text>().text = "Kig godt nede i bassinet. Rødspættens farve gør at den kan gemme sig godt!";
		}  else if(_name == "Crab") {
			achievementText.GetComponent<Text>().text = "Kig under krabben for at se dens køn. Hannen har en er spids trekant hvor hunnen har en bredt trekant!";
		}  else if(_name == "Killerwhale") {
			achievementText.GetComponent<Text>().text = "En spækhugger er omkring 2.4 meter når den bliver født og kan som voksen blive op til 9 meter!";
		}  else if(_name == "Shark") {
			achievementText.GetComponent<Text>().text = "Når en haj taber sin tand rykker tanden bagved frem da hajen har flere rækker af tænder!";
		}
	}

	public void PlaySound() {
		GetComponent<AudioSource> ().Play ();
	}
}
