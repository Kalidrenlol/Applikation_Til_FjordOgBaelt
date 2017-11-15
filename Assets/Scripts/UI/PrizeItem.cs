﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class PrizeItem : MonoBehaviour {

    [SerializeField] Text txt;
    [SerializeField] SVGImage img;

	public void Setup (int _no, bool _show, float _waitSeconds, List<string> aniSeen, SVGImage[] aniAll) {
        txt.text = _no.ToString();
       
        if (!_show) {
			img.color = Color.black;
            txt.color = Color.gray;
        } else {
			//Debug.Log (aniSeen[_no-1]);

			for(int i=0; i < aniAll.Length; i++) {
				//Debug.Log (aniAll[i].name);
				if (aniSeen[_no-1] == aniAll[i].name) {
					Debug.Log (aniAll[i].name);
					img.vectorGraphics = aniAll[i].vectorGraphics;
				}
			}


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
