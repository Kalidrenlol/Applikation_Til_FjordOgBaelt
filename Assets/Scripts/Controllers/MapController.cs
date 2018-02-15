using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;

public class MapController : MonoBehaviour {

	[SerializeField] Object[] pointers;

	void Start () {

		/*GameObject ParentMap = GameObject.FindGameObjectWithTag ("Map");

		foreach(GameObject pointer in pointers) {
			GameObject p = Instantiate (pointer);
			p.name = pointer.name;
			p.transform.SetParent(ParentMap.transform.GetChild (0), false);

			switch (p.gameObject.name) {
				case "Starfish":
					p.transform.localPosition = new Vector3 (152, 195, 0);
					break;
				case "Starfish2":
					p.transform.localPosition = new Vector3 (-131, 389, 0);
				break;
				case "Crap":
					p.transform.localPosition = new Vector3 (227, 275, 0);
					break;
				case "Crap2":
					p.transform.localPosition = new Vector3 (152, 250, 0);
					break;
				case "Seal":
					p.transform.localPosition = new Vector3 (51, 262, 0);
					break;
				case "Seal2":
					p.transform.localPosition = new Vector3 (-260, 136, 0);
					break;
				case "HarbourPorpoise":
					p.transform.localPosition = new Vector3 (-206, 32, 0);
					break;
				case "HarbourPorpoise2":
					p.transform.localPosition = new Vector3 (37, 389, 0);
					break;
				case "SeaGull":
					p.transform.localPosition = new Vector3 (150, 315, 0);
					break;
				case "Plaice":
					p.transform.localPosition = new Vector3 (-174, 299, 0);
					break;
				case "Shark":
					p.transform.localPosition = new Vector3 (282, 352, 0);
					break;
				case "Spermwhale":
					p.transform.localPosition = new Vector3 (-37, 365, 0);
					break;
				case "Killerwhale":
					p.transform.localPosition = new Vector3 (152, -76, 0);
					break;
			}

			p.GetComponent<SVGImage> ().color = new Color (1, 1, 1, 0.5f);
			p.transform.GetChild(0).GetComponent<SVGImage>().color = new Color (1, 1, 1, 0.5f);
		}*/
	}

	void Update () {
		
	}

	public void highlightAnimal(string animal) {
		GameObject ParentMap = GameObject.FindGameObjectWithTag ("Map");
		Transform p = ParentMap.transform.GetChild (0).GetChild (1).Find (animal);
		p.GetComponent<SVGImage> ().color = new Color (1, 1, 1, 1);
	}
}
