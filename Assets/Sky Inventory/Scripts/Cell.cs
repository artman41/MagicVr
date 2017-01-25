using UnityEngine;
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

	//Method to update UI of this cell
	public void UpdateCellInterface () {
		if (elementPrefab == null) {
			elementPrefab = (FindObjectOfType (typeof(ElementalInventory)) as ElementalInventory).elementPrefab;
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
			bgImage.color = elementColor;
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
		elementCount = 1;
        spell = s;
		elementColor = s.GetColour();
		UpdateCellInterface ();
	}

	//Clear element
	public void ClearElement () {
		elementCount = 0;
		UpdateCellInterface ();
	}

}
