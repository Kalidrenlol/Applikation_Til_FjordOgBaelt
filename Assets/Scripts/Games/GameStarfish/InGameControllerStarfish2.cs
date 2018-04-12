using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;
using System.IO;

public class InGameControllerStarfish2 : MonoBehaviour {

	[SerializeField] GameObject ShowWinningPrefab;
	[SerializeField] GameObject btnPic;

	private bool camAvail;
	private WebCamTexture backCam;
	private Texture defaultBack;
	public RawImage background;
	public AspectRatioFitter fit;

	void Start () {
		defaultBack = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0) {
			Debug.Log ("No Camera");
			camAvail = false;
			return;
		}

		for (int i = 0; i < devices.Length; i++) {
			if (!devices [i].isFrontFacing) {
				backCam = new WebCamTexture (devices [i].name, Screen.width, Screen.height);
			}
		}

		if (backCam == null) {
			Debug.Log("Unable to find back camera");
			return;
		}

		backCam.Play();
		background.texture = backCam;

		camAvail = true;

		btnPic.GetComponent<Button>().onClick.AddListener(delegate {
			Debug.Log("Picture Taken");
			StartCoroutine (takePhotoIEnum());
		});
	}

	private void Update () {
		if(!camAvail)
			return;

		float ratio = (float)backCam.width / (float)backCam.height;
		fit.aspectRatio = ratio;

		float scaleY = backCam.videoVerticallyMirrored ? -1f: 1f;
		background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

		int orient = -backCam.videoRotationAngle;
		background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
	}
		
	public IEnumerator takePhotoIEnum() {

		// NOTE - you almost certainly have to do this here:

		yield return new WaitForEndOfFrame(); 

		// it's a rare case where the Unity doco is pretty clear,
		// http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
		// be sure to scroll down to the SECOND long example on that doco page 

		Texture2D photo = new Texture2D(backCam.width, backCam.height);
		photo.SetPixels(backCam.GetPixels());
		photo.Apply();

		//Encode to a PNG
		byte[] bytes = photo.EncodeToPNG();
		//Write out the PNG. Of course you have to substitute your_path for something sensible
		//File.WriteAllBytes(Application.dataPath + "/../photo.png", bytes);
		SavePictureToGallery( bytes, "imgname.png" ); 
		ShowWinning();

	}

	#if !UNITY_EDITOR && UNITY_ANDROID
	    private static AndroidJavaClass m_ajc = null;

	    private static AndroidJavaClass AJC
	    {
	        get
	        {
	            if( m_ajc == null )
	                m_ajc = new AndroidJavaClass( "com.simsoft.sshelper.SSHelper" );
	 
	            return m_ajc;
	        }
	    }
	#endif
	 
    public static void SavePictureToGallery( byte[] bytes, string filename ) {
        string path = Path.Combine( GetPicturesFolderPath(), filename );
        if( !filename.EndsWith( ".png" ) )
            path += ".png";
 
        Debug.Log( "Saving to: " + path );
 
        File.WriteAllBytes( path, bytes );
	     
		#if !UNITY_EDITOR && UNITY_ANDROID
	        AndroidJavaObject context;
	        using( AndroidJavaClass unityClass = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" ) )
	        {
	            context = unityClass.GetStatic<AndroidJavaObject>( "currentActivity" );
	        }
	 
	        AJC.CallStatic( "MediaScanFile", context, path );
		#endif
    }
	 
    public static string GetPicturesFolderPath()
    {
		#if UNITY_EDITOR
	        return System.Environment.GetFolderPath( System.Environment.SpecialFolder.DesktopDirectory );
		#elif UNITY_ANDROID
	        return AJC.CallStatic<string>( "GetPicturesFolderPath", Application.productName );
		#else
	        return Application.persistentDataPath;
		#endif
    }

	public void ShowWinning() {
		GameObject showWinning = Instantiate(ShowWinningPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
		showWinning.GetComponent<Animator>().SetTrigger("Correct");
		showWinning.GetComponent<ResultController>().Setup("Shark", true);
		showWinning.GetComponent<ResultController>().resultBtn.onClick.AddListener(GoToMainScene);
	}

	void GoToMainScene() {
		GameObject controller = GameObject.FindGameObjectWithTag("GameController");
		controller.GetComponent<ScreenController>().ScreenTask.SetActive(false);
		controller.GetComponent<ScreenController>().GoToPage(1);
		controller.GetComponent<AnimalsController>().DiscoverAnimal("Shark");
		DestroyGame ();
	}

	public void DestroyGame() {
		Destroy(transform.parent.gameObject);
	}
}
