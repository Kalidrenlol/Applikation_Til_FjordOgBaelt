using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;

public class InGameModelCrab : MonoBehaviour {

	[SerializeField] public List<GameObject> TileMap;
	public GameObject startIndicator;
	public int PlayerPosition;
	public SVGAsset BorderPath;
	public SVGAsset CrabWon;
	public bool Rotated = false;
	public GameObject controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MoveLeft ()
	{
		if (startIndicator.activeSelf) {
			startIndicator.SetActive(false);
		}

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
		if (startIndicator.activeSelf) {
			startIndicator.SetActive(false);
		}

		if (Rotated) {

			if (PlayerPosition > 4) {
				if (PlayerPosition == 9) {
					TileMap [PlayerPosition - 5].GetComponent<SVGImage> ().vectorGraphics = CrabWon;
					TileMap [PlayerPosition - 5].transform.Rotate (0, 0, 0);
					PlayerPosition = PlayerPosition - 5;
					TileMap [PlayerPosition + 5].GetComponent<SVGImage> ().vectorGraphics = BorderPath;
					controller.GetComponent<InGameControllerCrab>().GameWon = true;
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
		if (startIndicator.activeSelf) {
			startIndicator.SetActive(false);
		}

		if (Rotated) {
			TileMap [PlayerPosition].transform.Rotate(0, 0, -90);
			Rotated = false;
		} else {
			TileMap [PlayerPosition].transform.Rotate(0, 0, 90);
			Rotated = true;
		}
	}
}
