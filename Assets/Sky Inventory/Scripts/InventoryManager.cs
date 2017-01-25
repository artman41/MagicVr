using UnityEngine;
using System.Collections;
using Assets.Scripts.Spells;

public class InventoryManager : MonoBehaviour {

	public ElementalInventory inventory;

    public Spell CurrentSpell;

	void Update () {
        if (inventory == null) {
			inventory = FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory;
            Initialize();
        }
    }

    void Initialize() {
        inventory.addItem(SpellFactory.AirSpell, 1);
        inventory.addItem(SpellFactory.FireSpell, 1);
        inventory.addItem(SpellFactory.WaterSpell, 1);
        inventory.addItem(SpellFactory.GroundSpell, 1);
        inventory.gameObject.SetActive(false);
    }

}
