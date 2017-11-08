using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class PrizeItem : MonoBehaviour {

    [SerializeField] Text txt;
    [SerializeField] SVGImage img;

	public void Setup (int _no, bool _show, float _waitSeconds) {
        txt.text = _no.ToString();
       
        if (!_show) {
			Debug.Log (img.color);
			img.color = Color.black;
            txt.color = Color.gray;
        } else {
            if (_waitSeconds > 0) {
                StartCoroutine(ShowAni(_waitSeconds));
            } else {
                GetComponent<Animator>().SetBool("Seen", true);
            }
           	img.color = Color.white;
            txt.color = Color.blue;
        }
    }

    IEnumerator ShowAni(float _seconds) {
        yield return new WaitForSeconds(_seconds);
        GetComponent<Animator>().SetTrigger("isNew");
    }
}
