using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DebugController : MonoBehaviour {

	[SerializeField] GameObject OtherScreens;
	[SerializeField] GameObject HorizontalContent;
	[SerializeField] GameObject TaskScreen;
	[SerializeField] GameObject AnimalView;

	void Awake () {
		GetComponent<ScreenController>().ScreenPrize.SetActive(true);
		GetComponent<ScreenController>().ScreenSettings.SetActive(true);
		OtherScreens.SetActive(true);
		TaskScreen.SetActive(false);
		AnimalView.SetActive(true);
		foreach(Transform child in HorizontalContent.transform) {
			child.gameObject.SetActive(true);
		}
	}

	#if UNITY_EDITOR
		[MenuItem("Genveje/Delete All PlayerPrefs")]
		static public void DeleteAllPlayerPrefs() {
			PlayerPrefs.DeleteAll();
			print("PlayerPrefs slettet");
		}
	#endif

    public void DeleteAllePlayerPrefs() {
		print("Delete All");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(0);
    }

}


