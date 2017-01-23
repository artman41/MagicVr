using UnityEngine;
using System.Collections;
using Assets.Scripts.Spells;

public class InventoryManager : MonoBehaviour {

	private ElementalInventory inventory;

	void Update () {
        #region Input
        if (inventory == null) {
			inventory = FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory;
            Initialize();
        }
		//if (Input.GetKeyDown (KeyCode.G)) {
		//	inventory.addItem (SimpleMethods.randomElement(), Random.Range(1, inventory.maxStack), new Color(Random.value/2f, Random.value/2f, Random.value/2f, 1f));
		//}
		if (Input.GetKeyDown (KeyCode.C)) {
			inventory.clear ();
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			PlayerPrefs.SetString ("EInventory", inventory.convertToString());
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			inventory.loadFromString (PlayerPrefs.GetString("EInventory"));
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
		//	inventory.gameObject.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Tab)) {
			inventory.gameObject.SetActive (!inventory.gameObject.activeInHierarchy);
		}
        #endregion
    }

    void Initialize() {
        inventory.addItem(SpellFactory.AirSpell, 1);
        inventory.addItem(SpellFactory.FireSpell, 1);
        inventory.addItem(SpellFactory.WaterSpell, 1);
        inventory.addItem(SpellFactory.GroundSpell, 1);
        inventory.gameObject.SetActive(false);
    }

}
