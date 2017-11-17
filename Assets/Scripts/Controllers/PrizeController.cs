using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SVGImporter;

public class PrizeController : MonoBehaviour {

    GameObject gameController;
    [SerializeField] GameObject content;
	[SerializeField] SVGImage[] animalList;

	public void Setup(List<string> animalsFound) {
		gameController = GameObject.FindGameObjectWithTag("GameController");
		int lastCount = gameController.GetComponent<AnimalsController>().lastCount;
		int i = 1;
        float sec = 0f;

        foreach (Transform child in content.transform) {
			bool _show = (animalsFound.Count >= i) ? true : false;
            if (_show && i > lastCount) sec+= 0.5f;

			child.GetComponent<PrizeItem>().Setup(i, _show, sec, animalsFound, animalList);
            i++;
        }
		gameController.GetComponent<AnimalsController>().SetLastCount(animalsFound.Count);
    }
}
