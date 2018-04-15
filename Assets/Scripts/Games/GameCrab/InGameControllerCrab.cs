using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class InGameControllerCrab : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	[SerializeField] public List<GameObject> TileMap;
	public int PlayerPosition;
	public SVGAsset BorderPath;
	public SVGAsset CrabWon;
	public bool Rotated = false;
	public bool GameWon = false;
	float timeLeft = 5.0f;

  	void Start () { }

    void Update ()
	{
		if (GameWon) {
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				ShowWinning();
				GameWon = false;
			}
		}
    }

    public void MoveLeft ()
	{
		if (Rotated) {
			if (PlayerPosition > 4) {
				if (PlayerPosition == 9) {
					TileMap [PlayerPosition - 5].GetComponent<SVGImage> ().vectorGraphics = CrabWon;
					TileMap [PlayerPosition - 5].transform.Rotate (0, 0, 0);
					PlayerPosition = PlayerPosition - 5;
					TileMap [PlayerPosition + 5].GetComponent<SVGImage> ().vectorGraphics = BorderPath;
					GameWon = true;
				} else {
					if (PlayerPosition != 24 && PlayerPosition != 18 && PlayerPosition != 16 && PlayerPosition != 10 && PlayerPosition != 8) {
						TileMap [PlayerPosition - 5].GetComponent<SVGImage> ().vectorGraphics = TileMap [PlayerPosition].GetComponent<SVGImage> ().vectorGraphics;
						TileMap [PlayerPosition - 5].transform.Rotate (0, 0, 90);
						PlayerPosition = PlayerPosition - 5;
						TileMap [PlayerPosition + 5].GetComponent<SVGImage> ().vectorGraphics = BorderPath;
						TileMap [PlayerPosition + 5].transform.Rotate (0, 0, -90);
					}
				}
			}
		} else {
			if (PlayerPosition > 0) {
				if (PlayerPosition != 5 && PlayerPosition != 10 && PlayerPosition != 15 && PlayerPosition != 20 && PlayerPosition != 23 && PlayerPosition != 12 &&  PlayerPosition != 6  &&  PlayerPosition != 14) {
					TileMap [PlayerPosition - 1].GetComponent<SVGImage> ().vectorGraphics = TileMap [PlayerPosition].GetComponent<SVGImage> ().vectorGraphics;
					PlayerPosition = PlayerPosition - 1;
					TileMap [PlayerPosition + 1].GetComponent<SVGImage> ().vectorGraphics = BorderPath;
				}
			}
		}
	}

	public void MoveRight ()
	{
		if (Rotated) {
			if (PlayerPosition < 20) {
				if (PlayerPosition != 17 && PlayerPosition != 14 && PlayerPosition != 8 && PlayerPosition != 6 && PlayerPosition != 0) {
					TileMap [PlayerPosition + 5].GetComponent<SVGImage> ().vectorGraphics = TileMap [PlayerPosition].GetComponent<SVGImage> ().vectorGraphics;
					TileMap [PlayerPosition + 5].transform.Rotate (0, 0, 90);
					PlayerPosition = PlayerPosition + 5;
					TileMap [PlayerPosition - 5].GetComponent<SVGImage> ().vectorGraphics = BorderPath;
					TileMap [PlayerPosition - 5].transform.Rotate (0, 0, -90);
				}
			}
		} else {
			if (PlayerPosition < TileMap.Count - 1) {
				if (PlayerPosition != 4 && PlayerPosition != 9 && PlayerPosition != 14 && PlayerPosition != 19 && PlayerPosition != 21 && PlayerPosition != 18 && PlayerPosition != 10 && PlayerPosition != 2 && PlayerPosition != 12) {
					TileMap [PlayerPosition + 1].GetComponent<SVGImage> ().vectorGraphics = TileMap [PlayerPosition].GetComponent<SVGImage> ().vectorGraphics;
					PlayerPosition = PlayerPosition + 1;
					TileMap [PlayerPosition - 1].GetComponent<SVGImage> ().vectorGraphics = BorderPath;
				}
			}
		}
	}

	public void Rotate () {
		if (Rotated) {
			TileMap [PlayerPosition].transform.Rotate(0, 0, -90);
			Rotated = false;
		} else {
			TileMap [PlayerPosition].transform.Rotate(0, 0, 90);
			Rotated = true;
		}
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Crab", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Crab");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
