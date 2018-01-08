using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Game_Starfish2 : MonoBehaviour {

	[SerializeField] Button btn;
	[SerializeField] Button btnPic;
	[SerializeField] GameObject frame;
	WebCamTexture webCamTexture;

	void Start () {
		webCamTexture = new WebCamTexture();
		frame = GameObject.FindWithTag ("CameraFrame");

		frame.GetComponent<Renderer>().material.mainTexture = webCamTexture;

		webCamTexture.Play();

		btn.onClick.AddListener(delegate {
			Destroy(transform.parent.gameObject);	
		});

		btnPic.onClick.AddListener(delegate {
			Debug.Log("Picture Taken");
			StartCoroutine (takePhotoIEnum());
		});
	}
		
	public IEnumerator takePhotoIEnum() {

		// NOTE - you almost certainly have to do this here:

		yield return new WaitForEndOfFrame(); 

		// it's a rare case where the Unity doco is pretty clear,
		// http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
		// be sure to scroll down to the SECOND long example on that doco page 

		Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
		photo.SetPixels(webCamTexture.GetPixels());
		photo.Apply();

		//Encode to a PNG
		byte[] bytes = photo.EncodeToPNG();
		//Write out the PNG. Of course you have to substitute your_path for something sensible
		File.WriteAllBytes(Application.dataPath + "/../photo.png", bytes);

		Debug.Log (Application.dataPath);
		Debug.Log (bytes);
	}

}
