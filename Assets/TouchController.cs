using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class TouchController : MonoBehaviour {

	public GameObject[] teeth;
	public GameObject ToothBrush;
	public GameObject BrushBubbles;
	public SVGImage ToothBrushPaste;
	public bool onTooth;
	public bool dragging = false;
	public Camera mainCamera;
	public int brush = 0;
	public int whitelevel;
	public int teethBrushed;

	void Start () {
		BrushBubbles.GetComponent<ParticleSystem> ().Stop(false, ParticleSystemStopBehavior.StopEmitting);
		whitelevel = 115; 
		teethBrushed = 0;

		ToothBrush.GetComponent<Button>().onClick.AddListener(() => {
			ToothBrush.GetComponent<SVGImage>().vectorGraphics = ToothBrushPaste.vectorGraphics;
			dragging = true;
			ToothBrush.GetComponent<Button>().onClick.RemoveAllListeners();
			Debug.Log("Clicked");
		});

	}

	void Update () {
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began) { Debug.Log ("Began"); }
			if (touch.phase == TouchPhase.Ended) { Debug.Log ("Ended");BrushBubbles.GetComponent<ParticleSystem> ().Stop(false, ParticleSystemStopBehavior.StopEmitting); }
			if (touch.phase == TouchPhase.Stationary) { Debug.Log ("Stationary");BrushBubbles.GetComponent<ParticleSystem> ().Play(false); }
			if (touch.phase == TouchPhase.Canceled) { Debug.Log ("Canceled");}

			foreach (GameObject tooth in teeth) {
				onTooth = RectTransformUtility.RectangleContainsScreenPoint (tooth.GetComponent<RectTransform>(), new Vector3(touch.position.x-200, touch.position.y), mainCamera);

				if (onTooth == true) {
					brushTooth (tooth);
					brush++;
					break;
				}
			}

			if (dragging) {
				Debug.Log ("Draggin");
				ToothBrush.gameObject.transform.position = new Vector3(touch.position.x, touch.position.y);
			}
		}
	}

	void brushTooth(GameObject tooth) {
		if (brush > 10 && tooth.GetComponent<Tooth>().whitelevel < 255) {
			Debug.Log ("Brushing");
			tooth.GetComponent<Tooth>().whitelevel = tooth.GetComponent<Tooth>().whitelevel + 20;
			brush = 0;
			tooth.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, (byte)tooth.GetComponent<Tooth>().whitelevel, 255);
		}
	}
}
