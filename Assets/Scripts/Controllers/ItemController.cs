using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SVGImporter;

public class ItemController : MonoBehaviour {

	public GameObject itemView;

	[SerializeField] Object[] items;
	[SerializeField] Transform itemContent;
	[SerializeField] GameObject itemObjectPrefab;

	[Header("Image Target")]
	List<GameObject> imageTargets = new List<GameObject>();
	[SerializeField] Transform imageTargetParent;
	[SerializeField] GameObject imageTargetPrefab;

	public int lastCount;
	[SerializeField] Image iconTrophy;

	bool hackAnimation = false;
	public GameObject mapcontrol;

	// Use this for initialization
	void Awake () {
		SetLastCount();

		CreateItems();
		UpdateItems();
		//CreateImageTargets();
	}

	void Update() {
		if (!hackAnimation) {
			hackAnimation = true;
			UpdateItems ();
		}
	}

	void SetLastCount() {
		if (PlayerPrefs.HasKey("ItemsLastSeen")) {
			lastCount = PlayerPrefs.GetInt("ItemsLastSeen");
		} else {
			lastCount = 0;
			PlayerPrefs.SetInt("ItemsLastSeen", lastCount);
		}
	}

	public void SetLastCount(int _count) {
		lastCount = _count;
		PlayerPrefs.SetInt("ItemsLastSeen", _count);
	}

    public int GetItemSeen() {
        int i = 0;
        foreach(GameObject item in items) {
            if (item.GetComponent<Animal>().HasSeen) {
                i++;
            }
        }
        return i;
    }

	public List<Item> GetItems() {
		List<Item> _items = new List<Item>();
		foreach(GameObject obj in items) {
			_items.Add(obj.GetComponent<Item>());
		}
		return _items;
	}

	public Item GetItem(string _item) {
		foreach(GameObject item in items) {
			if (item.GetComponent<Item>().englishName == _item) {
				return item.GetComponent<Item>();
			}
		}
		print("ØV det virker ikke");
		return null;
	}

	void CreateItems() {
		items = Resources.LoadAll("Items");

		foreach(GameObject item in items) {
			item.GetComponent<Item>().Setup();
		}
	}
	
	public void UpdateItems() {
		foreach(Transform child in itemContent) {
			Destroy(child.gameObject);
		}

		foreach(GameObject item in items) {
			GameObject obj = Instantiate(itemObjectPrefab, itemContent, false);
			obj.name = item.name;
			obj.GetComponent<ItemObject>().Setup(item.GetComponent<Item>());

			if (item.GetComponent<Item>().HasSeen) {
				mapcontrol.GetComponent<MapController> ().changePointerToFound (item.name);
			}
		}
	}

	public void DiscoverItem(string _name) {
		foreach (GameObject item in items) {
			if (item.GetComponent<Item>().englishName == _name) {
				PlayerPrefs.SetInt(_name + "_hasSeen", 1);

				item.GetComponent<Item>().HasSeen = true;
				item.GetComponent<Item>().NewDiscover = true;
				break;
			}
		}

		hackAnimation = false;
		UpdateItems();
	}

	public void DiscoverItem(Item _item) {
		PlayerPrefs.SetInt(_item.englishName + "_hasSeen", 1);
		_item.HasSeen = true;
		_item.NewDiscover = true;
		hackAnimation = false;

		UpdateItems();
	}

	void CreateImageTargets() {
		foreach(GameObject item in items) {
			GameObject target = (GameObject) Instantiate(imageTargetPrefab, imageTargetParent);
			target.name = item.GetComponent<Item>().englishName;

			imageTargets.Add(target);
		}
	}
}
