using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapZoom : MonoBehaviour {

	public Animator anim;
	public GameObject topBar;
	public GameObject mapBasement;
	public GameObject mapGround;
	public GameObject mapFirst;

	void Update()
	{
		
	}

	public void changeFloor(string floor) {
		if (floor == "-1") {
			mapBasement.SetActive (true);
			mapGround.SetActive (false);
			mapFirst.SetActive (false);
		} else if (floor == "0") {
			mapBasement.SetActive (false);
			mapGround.SetActive (true);
			mapFirst.SetActive (false);
		} else if (floor == "1") {
			mapBasement.SetActive (false);
			mapGround.SetActive (false);
			mapFirst.SetActive (true);
		}
	}

	public void ZoomTo1() {
		if (!anim.GetBool ("ZoomTo1")) {
			anim.SetBool ("ZoomTo1", true);
		} else if(anim.GetBool("ZoomTo1")) {
			anim.SetBool ("ZoomTo1", false);
		}
	}

	public void ZoomTo2() {
		if (!anim.GetBool ("ZoomTo2")) {
			anim.SetBool ("ZoomTo2", true);
		} else if(anim.GetBool("ZoomTo2")) {
			anim.SetBool ("ZoomTo2", false);
		}
	}

	public void ZoomTo3() {
		if (!anim.GetBool ("ZoomTo3")) {
			anim.SetBool ("ZoomTo3", true);
		} else if(anim.GetBool("ZoomTo3")) {
			anim.SetBool ("ZoomTo3", false);
		}
	}

	public void ZoomTo4() {
		if (!anim.GetBool ("ZoomTo4")) {
			anim.SetBool ("ZoomTo4", true);
		} else if(anim.GetBool("ZoomTo4")) {
			anim.SetBool ("ZoomTo4", false);
		}
	}

	public void ZoomTo5() {
		if (!anim.GetBool ("ZoomTo5")) {
			anim.SetBool ("ZoomTo5", true);
		} else if(anim.GetBool("ZoomTo5")) {
			anim.SetBool ("ZoomTo5", false);
		}
	}

	public void ZoomTo6() {
		if (!anim.GetBool ("ZoomTo6")) {
			anim.SetBool ("ZoomTo6", true);
		} else if(anim.GetBool("ZoomTo6")) {
			anim.SetBool ("ZoomTo6", false);
		}
	}
}
