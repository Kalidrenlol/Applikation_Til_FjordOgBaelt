using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_FeedHarbour : MonoBehaviour {

	[SerializeField] GameObject FishPrefab;
	[SerializeField] Transform imageTargetTransform;
	[SerializeField] Transform fishStartPos;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			GameObject fish = Instantiate(FishPrefab, imageTargetTransform);
			fish.transform.position = fishStartPos.position;
			fish.GetComponent<Game_ThrowingFish>().Throw();
		}
	}

}
