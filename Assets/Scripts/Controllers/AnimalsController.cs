using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class AnimalsController : MonoBehaviour {

	public GameObject animalView;

	[SerializeField] Object[] animals;
	[SerializeField] Transform animalContent;
	[SerializeField] GameObject animalObject;

	[Header("Image Target")]
	List<GameObject> imageTargets = new List<GameObject>();
	[SerializeField] Transform imageTargetParent;
	[SerializeField] GameObject imageTargetPrefab;

	[HideInInspector] public int lastCount;
	public GameObject starPrefab;
	public Transform juicynessFolder;
	bool hackUpdate = false;
	int animalsHelped;

	void Awake () {
		SetLastCount();
		CreateAnimals();
	}

	void Start() {
		UpdateAnimals ();
	}

	void Update() {
		if (!hackUpdate) {
			hackUpdate = true;
			UpdateAnimals();
		}
	}

	void SetLastCount() {
		if (PlayerPrefs.HasKey("AnimalsLastSeen")) {
			lastCount = PlayerPrefs.GetInt("AnimalsLastSeen");
		} else {
			lastCount = 0;
			PlayerPrefs.SetInt("AnimalsLastSeen", lastCount);
		}
	}

	public void SetLastCount(int _count) {
		lastCount = _count;
		PlayerPrefs.SetInt("AnimalsLastSeen", _count);
	}

	public List<string> GetAnimalSeen() {

		SortedDictionary<int, GameObject> sortedAnimals = new SortedDictionary<int, GameObject>();
		List<string> foundAnimals = new List<string> ();

		foreach (GameObject ani in animals) {
			if (ani.GetComponent<Animal> ().HasSeen) {			
				sortedAnimals.Add (ani.GetComponent<Animal> ().seenIndex-1, ani);
			}
		}

		foreach(KeyValuePair<int, GameObject> ani in sortedAnimals)
		{
			foundAnimals.Add (ani.Value.gameObject.name);
		}
		return foundAnimals;
    }

	public Animal GetAnimal(string _animal) {
		foreach(GameObject ani in animals) {
			if (ani.GetComponent<Animal>().englishName == _animal) {
				return ani.GetComponent<Animal>();
			}
		}
		print("ØV det virker ikke: " + _animal);
		return null;
	}

	void CreateAnimals() {
		animals = Resources.LoadAll("Animals");

		for (var i = animals.Length - 1; i > 0; i--) {
				var r = Random.Range(0, i);
				Object tmp = animals[i];
				animals[i] = animals[r];
				animals[r] = tmp;
			}


		foreach(GameObject ani in animals) {
			ani.GetComponent<Animal>().Setup();
		}
	}
	
	public void UpdateAnimals() {
		foreach(Transform child in animalContent) {
			Destroy(child.gameObject);
		}

		int helped = 0;

		foreach(GameObject animal in animals) {
			GameObject obj = Instantiate(animalObject, animalContent, false);
			obj.name = animal.name;
			obj.GetComponent<AnimalObject>().Setup(animal.GetComponent<Animal>(), obj);
			if (animal.GetComponent<Animal>().HasSeen) {
				helped++;
			}
		}
		int total = animals.Length;
		animalsHelped = helped;
	}

	public void DiscoverAnimal(string _name) {
		bool hasBeenHelped = false;

		foreach (GameObject ani in animals) {
            if (ani.GetComponent<Animal>().danishName == _name) {
				_name = ani.GetComponent<Animal>().englishName;
                break;
            }
        }

        foreach (GameObject ani in animals) {
            if (ani.GetComponent<Animal>().englishName == _name) {
                PlayerPrefs.SetInt(_name + "_hasSeen", 1);
				PlayerPrefs.SetInt(_name + "_newDiscover", 1);
				int animalsHelpedIndex = animalsHelped + 1;

				PlayerPrefs.SetInt ("A_" + _name + "_seenIndex", animalsHelpedIndex);
				ani.GetComponent<Animal> ().seenIndex = PlayerPrefs.GetInt ("A_" + _name + "_seenIndex");

				hasBeenHelped = true;
                ani.GetComponent<Animal>().HasSeen = true;
                ani.GetComponent<Animal>().NewDiscover = true;

                break;
            }
        }

		if (!hasBeenHelped) {
			Debug.LogError(_name + " skulle være hjulpet, men blev ikke fundet");
		}
        UpdateAnimals();
	}
}
