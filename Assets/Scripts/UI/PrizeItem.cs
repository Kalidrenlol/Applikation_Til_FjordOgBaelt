using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeItem : MonoBehaviour {

    [SerializeField] Text txt;
    [SerializeField] Image img;

	public void Setup (int _no, bool _show, float _waitSeconds) {
        txt.text = _no.ToString();
       
        if (!_show) {
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
