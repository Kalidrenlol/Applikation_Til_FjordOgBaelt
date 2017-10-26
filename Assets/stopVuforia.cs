using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class stopVuforia : MonoBehaviour {
		
	void Start () {
		VuforiaBehaviour.Instance.enabled = false;
	}
}
