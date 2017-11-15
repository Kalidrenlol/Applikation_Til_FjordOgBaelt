using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;

public class PrizeController : MonoBehaviour {

    GameObject gameController;
    [SerializeField] GameObject content;
	[SerializeField] SVGImage[] _animalList;

	public void Setup(List<string> _list) {
		gameController = GameObject.FindGameObjectWithTag("GameController");
		int lastCount = gameController.GetComponent<AnimalsController>().lastCount;
		int i = 1;
        float sec = 0f;
		Debug.Log (_list.Count);
        foreach (Transform child in content.transform) {
			bool _show = (_list.Count >= i) ? true : false;
            if (_show && i > lastCount) sec+= 0.5f;

			child.GetComponent<PrizeItem>().Setup(i, _show, sec, _list, _animalList);
            i++;
        }
		gameController.GetComponent<AnimalsController>().SetLastCount(_list.Count);
    }
}
