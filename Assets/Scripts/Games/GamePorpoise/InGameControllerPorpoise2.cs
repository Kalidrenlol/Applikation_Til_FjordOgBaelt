using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameControllerPorpoise2 : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	public bool showWinning = false;
	public GameObject ButtonLeft;
	public GameObject ButtonRight;
	public GameObject ButtonUp;
	public GameObject Porpoise;
	public GameObject FishGood;
	public GameObject FishBad;
	public GameObject Slider;
	public float speed;
	public bool facingRight;

	public bool Rcoll;
	public bool Lcoll;

	void Start () {
		SpawnFish();
		SpawnFish();
		SpawnFish();
	}

    void FixedUpdate ()
	{
		if (ButtonLeft.GetComponent<ButtonInteraction> ().Pressed && !Lcoll) {
			Porpoise.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, Porpoise.GetComponent<Rigidbody2D> ().velocity.y);
			if (!facingRight)
				Flip ();
		} else {
			Porpoise.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, Porpoise.GetComponent<Rigidbody2D> ().velocity.y);
		}

		if (ButtonRight.GetComponent<ButtonInteraction> ().Pressed && !Rcoll) {
			Porpoise.GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, Porpoise.GetComponent<Rigidbody2D> ().velocity.y);
			if (facingRight)
				Flip ();
		}      

		if (ButtonUp.GetComponent<ButtonInteraction> ().Pressed) {
			if (!facingRight) {
				Porpoise.GetComponent<Animation> ().Play ("PorpoiseJumpRight");
			} else {
				Porpoise.GetComponent<Animation> ().Play ("PorpoiseJumpLeft");
			}
		}

		if (Porpoise.GetComponent<RectTransform> ().offsetMin.x < (-Screen.width/2)+(Porpoise.GetComponent<Collider2D>().bounds.size.x/2)) {
			Lcoll = true;
		} else {
			Lcoll = false;
		}

		if (Porpoise.GetComponent<RectTransform> ().offsetMax.x > (Screen.width/2)-(Porpoise.GetComponent<Collider2D>().bounds.size.x/2)) {
			Rcoll = true;
		} else {
			Rcoll = false;
		}

		if(Slider.GetComponent<Slider>().value == 7 && showWinning == false) {
			ShowWinning();
			showWinning = true;
		}
    }

    void Flip () {
        facingRight = !facingRight;
        Porpoise.transform.Rotate(Vector3.up * 180);
    }

	public void SpawnFish () {
		int i = Random.Range (0, 3);
		GameObject co;

		if (i > 0) {
			co = Instantiate (FishGood) as GameObject;
		} else {
			co = Instantiate (FishBad) as GameObject;
		}
	
		co.transform.parent = Slider.transform.parent;
		co.transform.position = new Vector3(Random.Range(0, Screen.width),Slider.transform.position.y, 0);
	}

	public void UpdateProgress (int i) {
		Slider.GetComponent<Slider>().value = Slider.GetComponent<Slider>().value +i;
	}

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("HarbourPorpoise2", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("HarbourPorpoise2");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
