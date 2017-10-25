using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour {

	public enum GameState {GameStart, Plaice, Seal, Shark, Porpoise, Spermwhale, Starfish2}

	public GameState gameState;
	GameObject gameController;
	int state;

	[SerializeField] Text txtSummary;
	Button btn;

	void Awake() {
		gameController = GameObject.FindGameObjectWithTag("GameController");
        btn = GetComponent<Button>();

		switch (gameState) {
		case GameState.Plaice:
			state = 0;
			Game_Plaice(state);
			break;
		case GameState.GameStart:
			state = PlayerPrefs.GetInt("ShowTutorial");
			if (state == 0) {
				GoToState(state);
			}
			break;
		case GameState.Seal:
			state = 0;
			Game_Seal(state);
			break;
		case GameState.Porpoise:
			state = 0;
			Game_Porpoise(state);
			break;
		case GameState.Shark:
			state = 0;
			Game_Shark(state);
			break;
		case GameState.Spermwhale:
			state = 0;
			Game_Spermwhale(state);
			break;
		case GameState.Starfish2:
			state = 0;
			Game_Starfish2(state);
			break;
		default:
			break;
		}

	}

	#region Porpoise
	public void Game_Porpoise(int _no) {
		string _text = "";

		switch (_no) {
		case 0:
			_text = "Dette er et marsvin. Den mangler noget at spise.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				if (GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemController>().GetItem("BucketFish").HasSeen) {
					state++;				
				} else {
					state = 5;
				}
				Game_Porpoise(state);
			});
			break;
		case 1:
			_text = "Har du noget at fodre den med?";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Porpoise(state);
			});
			break;
		case 2:
			_text = "Sådan! Vi fodrede dyret med fisk!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<AnimalsController>().DiscoverAnimal("HarbourPorpoise");
				Destroy(transform.parent.parent.gameObject);
			});
			break;
		case 5:
			_text = "Hov! Du mangler noget at fodre den med. Kom tilbage senere.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				Destroy(transform.parent.parent.gameObject);
			});
			break;
		default:
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
		}

		txtSummary.text = _text;
	}



	#endregion

	#region Shark

	public void Game_Shark(int _no) {
		string _text = "";

		switch (_no) {
		case 0:
			_text = "Av! Hajen har virkelig ondt i munden. Det ser ud som om, at den har tabt en tand.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				if (GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemController>().GetItem("Tooth").HasSeen) {
					state++;				
				} else {
					state = 6;
				}
				Game_Shark(state);
			});
			break;
		case 1:
			_text = "Kig i din taske og se om du kan hjælpe den.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Shark(state);
			});
			break;
		case 3:
			_text = "Hov! Det er vist ikke helt rigtigt. Prøv igen.";
			GetComponent<Animator>().SetTrigger("Attend");
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				GetComponent<Animator>().SetTrigger("Leave");
				btn.onClick.RemoveAllListeners();
			});
			break;
		case 4:
			_text = "Sådan! Vi gav hajen sin tabte tand tilbage!";
			GetComponent<Animator>().SetTrigger("Attend");
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<AnimalsController>().DiscoverAnimal("Shark");
				Destroy(transform.parent.parent.gameObject);
			});
			break;
		case 6:
			_text = "Øv! Vi kan ikke hjælpe hajen lige nu. Kom tilbage senere.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				Destroy(transform.parent.parent.gameObject);
			});
			break;
		default:
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
		}

		txtSummary.text = _text;
	}


	#endregion

	#region Starfish2

	public void Game_Starfish2(int _no) {
		string _text = "";

		switch (_no) {
		case 0:
			_text = "Dette er en søstjerne. Der er en silhouette.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				if (GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemController>().GetItem("Anchor").HasSeen) {
					state++;				
				} else {
					state = 5;
				}
				Game_Starfish2(state);
			});
			break;
		case 1:
			_text = "Har du noget der passer i formen?";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Starfish2(state);
			});
			break;
		case 2:
			_text = "Sådan! Vi havde noget der passede i formen!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<AnimalsController>().DiscoverAnimal("Starfish2");
				Destroy(transform.parent.parent.gameObject);
			});
			break;

		case 5:
			_text = "Øv! Vi kan ikke hjælpe søstjernen lige nu. Kom tilbage senere.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				Destroy(transform.parent.parent.gameObject);
			});
			break;
		default:
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
		}

		txtSummary.text = _text;
	}


	#endregion

	#region Spermwhale

	public void Game_Spermwhale(int _no) {
		string _text = "";

		switch (_no) {
		case 0:
			_text = "Det ligner at der mangler noget i kaskelothvalens skelet.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				if (GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemController>().GetItem("Vertebra").HasSeen) {
					state++;				
				} else {
					state = 5;
				}
				Game_Spermwhale(state);
			});
			break;
		case 1:
			_text = "Har du noget at udfylde skelettet med?";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Spermwhale(state);
			});
			break;
		case 2:
			_text = "Sådan! Vi satte ryghvirvlen på plads i skelettet!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<AnimalsController>().DiscoverAnimal("Spermwhale");
				Destroy(transform.parent.parent.gameObject);
			});
			break;

		case 5:
			_text = "Øv! Vi kan ikke hjælpe kasketlothvalen lige nu. Kom tilbage senere.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				Destroy(transform.parent.parent.gameObject);
			});
			break;
		default:
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
		}

		txtSummary.text = _text;
	}



	#endregion

	#region Plaice
	public void Game_Plaice(int _no) {
		string _text = "";

		switch (_no) {
		case 0:
			_text = "Åh nej! Rødspætten har tabt sine pletter.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Plaice(state);
			});
			break;
		case 1:
			_text = "Vælg den rigtige farve i bunden og tryk på pletterne for at farve dem.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Plaice(state);
			});
			break;
		case 2:
			_text = "Forhåbentlig får rødspætten Riggi snart sine pletter igen.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Plaice(state);
			});
			break;
		default:
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
		}

		txtSummary.text = _text;
	}

	public void Game_Plaice(bool _done) {
		string _text = "";

		GetComponent<Animator>().SetTrigger("Attend");
		switch (_done) {
		case true:
			_text = "Sådan! Nu er Riggi klar til at hoppe i vandet igen. Godt klaret!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				GetComponent<Animator>().SetTrigger("Leave");
				btn.onClick.RemoveAllListeners();
				GameObject.FindGameObjectWithTag("InGameController").GetComponent<Animator>().SetTrigger("Correct");
			});
			break;
		case false:
			_text = "Hov. Det er vist ikke helt rigtigt. Prøv igen.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				GetComponent<Animator>().SetTrigger("Leave");
				btn.onClick.RemoveAllListeners();
			});
			break;
		default:
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
		}

		txtSummary.text = _text;
	}

	#endregion

	#region Seal
	public void Game_Seal(int _no) {
		string _text = "";

		switch (_no) {
		case 0:
			_text = "Sælerne her i Fjord&Bælt er trænet til at gøre forskellige ting på kommando.";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Seal(state);
			});
			break;
		case 1:
			_text = "Måske vi kan få sælens til at rulle rundt, hvis vi kilder den på maven?";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				if (GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemController>().GetItem("Feather").HasSeen) {
					state++;				
				} else {
					state = 5;
				}
				Game_Seal(state);
			});
			break;
		case 2:
			_text = "Har du noget i din kiste vi kan kilde den med?";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				Game_Seal(state);
				//Show Bag //
			});
			break;
		case 3:
			_text = "Sådan! Vi fjernede sælen ved at kilde den!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<AnimalsController>().DiscoverAnimal("Seal");
				Destroy(transform.parent.parent.gameObject);
			});
			break;

		case 5:
			_text = "Du mangler at finde noget, vi kan kilde sælen med. Led videre i centeret!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				Destroy(transform.parent.parent.gameObject);
			});
			break;
		default:
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
		}

		txtSummary.text = _text;
	}

	#endregion

	#region StartTutorial
	public void GoToState(int _no) {
		string _text = "";
		print (_no);
		switch (_no) {
            case 0:

            _text = "I Fjord & Bælt har vi mange dyr, som du skal se!";
			btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(delegate {
                state++;
                GoToState(state);
            });
            break;
            case 1:
            _text = "Nogle dyr har opgaver, som du kan hjælpe dem med at løse.";
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(delegate {
                state++;
                GoToState(state);
            });
            break;
        case 2:
            _text = "På denne side kan du se, hvilke dyr der har opgaver til dig.";
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(delegate {
                gameController.GetComponent<ScreenController>().MenuObject.GoToScreen(0);
                state++;
                GoToState(state);
            });
            break;
        case 3:
			_text = "Her ser du kortet over Fjord & Bælt. Her kan du se hvor dyrene befinder sig";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<ScreenController>().MenuObject.GoToScreen(2);
				state++;
				GoToState(state);
			});
			break;
		case 4:
			_text = "Nogle dyr efterlader ting. De ting kan du se i din taske!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<ScreenController>().MenuObject.GoToScreen(1);
				state++;
				GoToState(state);
			});
			break;
		case 5:
			_text = "Dyrene har et billede, du skal scanne med din telefon. Scan og hjælp så mange dyr som muligt!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				gameController.GetComponent<ScreenController>().MenuObject.GoToScreen(1);
				state++;
				GoToState(state);
			});
			break;
        case 6:
            _text = "Når du har hjulpet alle dyrene, får du en præmie!";
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(delegate {
                gameController.GetComponent<ScreenController>().MenuObject.GoToScreen(1);
                state++;
                GoToState(state);
				btn.onClick.RemoveAllListeners();
            });
            break;
		case 7:
			PlayerPrefs.SetInt("ShowTutorial", 7);
			GetComponent<Animator>().SetTrigger("Leave");
			break;
		case 10:
			state = _no;
			_text = "Sådan! Du har lige hjulpet det første dyr! Lad os lige se dine fremskridt inde på skattekortet!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				GoToState(state);
			});
			//GetComponent<Animator>().SetTrigger("Attend");
			break;
		case 11:
			gameController.GetComponent<ScreenController>().ShowPrize(true);
			_text = "Her kan du holde øje med hvor mange dyr du har hjulpet. Hjælp alle dyrene og få fat i skatten!";
			btn.onClick.RemoveAllListeners();
			btn.onClick.AddListener(delegate {
				state++;
				GoToState(state);
			});
			break;
		case 12:
			print("Første dyr hjulpet");
			PlayerPrefs.SetInt("ShowTutorial", 12);
			GetComponent<Animator>().SetTrigger("Leave");
			btn.onClick.RemoveAllListeners();
			break;
        default:
			print("Tutorial Case uden for rækkevidde");
			break;
		}

		txtSummary.text = _text;
	}

	#endregion

	void DeativateTutorial() {
		gameObject.SetActive(false);
	}
}
