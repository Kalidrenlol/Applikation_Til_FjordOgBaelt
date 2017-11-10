using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeController : MonoBehaviour {

    GameObject gameController;
    [SerializeField] GameObject content;

	public void Setup(List<string> _list) {
		gameController = GameObject.FindGameObjectWithTag("GameController");
		int lastCount = gameController.GetComponent<AnimalsController>().lastCount;
		int i = 1;
        float sec = 0f;
		Debug.Log (_list.Count);
        foreach (Transform child in content.transform) {
			bool _show = (_list.Count >= i) ? true : false;
            if (_show && i > lastCount) sec+= 0.5f;

			child.GetComponent<PrizeItem>().Setup(i, _show, sec, _list[i-1]);
            i++;
        }
		gameController.GetComponent<AnimalsController>().SetLastCount(_list.Count);
    }
}
