﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts.Spells;
using System.Linq;

public class Cell : MonoBehaviour {

	public string elementName; // Element Name
	public int elementCount; // Element Count
    public Spell spell;
	public Color elementColor; // Element Color
	public Transform elementTransform; //Transform Element
	private GameObject elementPrefab;
    GameObject spellPrefab;

	//Method to update UI of this cell
	public void UpdateCellInterface () {
		if (elementPrefab == null) {
			elementPrefab = (FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory).elementPrefab;
		}
        if (spell != null) {
            spellPrefab = SpellEffect.GetGameObject(spell.Effect.Element);
            Destroy(spellPrefab.GetComponent<Rigidbody>());
            Destroy(spellPrefab.GetComponent<SphereCollider>());
            spellPrefab.transform.parent = this.transform;
            float radius = 60f;
            spellPrefab.transform.localScale = new Vector3(radius, radius, radius);
            spellPrefab.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            spellPrefab.transform.localPosition = Vector3.zero;
        }
		if (elementCount == 0) {
			if (elementTransform != null) {
				Destroy (elementTransform.gameObject);
			}
			return;
		}
		else {
			if (elementTransform == null) {
				//spawn a new element prefab
				Transform newElement = Instantiate (elementPrefab).transform;
				newElement.parent = transform;
				newElement.localPosition = new Vector3 ();
				newElement.localScale = new Vector3 (1f,1f,1f);
				elementTransform = newElement;
			}
			//init UI elements
			Image bgImage = SimpleMethods.getChildByTag (elementTransform, "backgroundImage").GetComponent<Image> ();
			Text elementText = SimpleMethods.getChildByTag (elementTransform, "elementText").GetComponent<Text> ();
            //Text amountText = SimpleMethods.getChildByTag (elementTransform, "amountText").GetComponent<Text> ();
            //change UI options
            //bgImage.color = elementColor;
            bgImage.gameObject.SetActive(false);
            elementText.text = elementName;
            Image i = elementText.GetComponentInChildren<Image>();
            i.gameObject.SetActive(false);

            var pft = elementTransform.GetComponent<Transform>();
            var ats = pft.GetComponentsInChildren<CanvasRenderer>();
            GameObject at = ats.Where(o => o.name == "AmountText").ToArray().First().gameObject;
            at.SetActive(false);
            elementText.fontSize = 12;
			//amountText.text = elementCount.ToString ();
		}
	}

    void Update() {
        if (elementTransform != null) {
            elementTransform.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

	//Change element options
	public void ChangeElement (Spell s) {
		elementName = s.Name;
        spell = s;
        elementCount = 1;
        UpdateCellInterface ();
	}

	//Clear element
	public void ClearElement () {
		elementCount = 0;
		UpdateCellInterface ();
	}

}
