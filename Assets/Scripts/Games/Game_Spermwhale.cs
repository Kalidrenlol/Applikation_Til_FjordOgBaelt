using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Spermwhale : MonoBehaviour {

	[SerializeField] Button btn;

	void Start () {
		btn.onClick.AddListener(delegate {
			Destroy(transform.parent.gameObject);	
		});
	}

}
