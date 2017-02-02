using UnityEngine;
using System.Collections;
using Assets.Scripts.Spells;
using Assets.Scripts;

public class ElementalInventory : MonoBehaviour {

	//Cell massive
	public Cell[] Cells;
	//Max element stack
	public int maxStack;
	public GameObject elementPrefab;
	private Transform choosenItem;

	public bool contains (string name, int count, Color color) {
		int inventoryCount = 0;
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0 && Cells [i].elementName == name && Cells [i].elementColor == color) {
				inventoryCount += Cells [i].elementCount;
			}
		}
		if (count <= inventoryCount) {
			return true;
		} else {
			return false;
		}
	}

    void OnActive() {
        this.loadFromString(PlayerPrefs.GetString("EInventory"));
    }

    void OnDisable() {
        PlayerPrefs.SetString("EInventory", this.convertToString());
    }

	//Set item from link
	public void setItemLink (string name, int count, Color color, Transform cell) {
		Cell thisCell = cell.GetComponent<Cell> ();
		thisCell.elementName = name;
		thisCell.elementCount = count;
		thisCell.elementColor = color;
	}

	//Moves item
	public void moveItem (int moveFrom, int moveTo) {
		setItem (Cells[moveFrom].spell, moveTo);
		setItem (null, moveFrom);
	}

	//Moves item with link
	//First - element, second - cell
	public void moveItemLink (Transform moveFrom, Transform moveTo) {
		if (moveFrom != null && moveTo != null) {
			Cell moveFromCell = moveFrom.parent.GetComponent<Cell> ();
			moveTo.GetComponent<Cell> ().elementTransform = moveFromCell.elementTransform;
			moveFromCell.elementTransform = null;
			setItemLink (moveFromCell.elementName, moveFromCell.elementCount, moveFromCell.elementColor, moveTo);
			moveFromCell.elementCount = 0;
			moveFrom.parent = moveTo;
			moveFrom.localPosition = new Vector3 ();
		}
	}

	public void moveItemLinkFirst (Transform t) {
		choosenItem = t;
	}

	public void moveItemLinkSecond (Transform t) {
		moveItemLink (choosenItem, t);
		choosenItem = null;
	}

	//Sets item
	public void setItem (Spell s, int cellId) {
        if(s == null) {
            Cells[cellId].elementCount = 0;
            return;
        }
		Cells [cellId].ChangeElement (s);
		Cells [cellId].UpdateCellInterface ();
	}

	//Loads inventory from string
	public void loadFromString (string s_Inventory) {
		string[] splitedInventory = s_Inventory.Split ("\n"[0]);
		for (int i = 0; i < Cells.Length; i++) {
			string[] splitedLine = splitedInventory [i].Split('\\');
            string[] splitEffect = splitedLine[2].Split('-');
			setItem(SpellFactory.CreateSpell(splitedLine[0], splitedLine[1], new SpellEffect(SpellEffect.GetElementFromString(splitEffect[0]), SpellEffect.GetShapeFromString(splitEffect[1]), SpellEffect.GetModifiersFromString(splitEffect[2].ToArray(true)))), i);
		}
	}

	//Returns inventory as string
	public string convertToString () {
		string s_Inventory = "";
		for (int i = 0; i < Cells.Length; i++) {
            if (Cells[i].spell != null) {
                s_Inventory += string.Format("{0}\\{1}\\{2}\\", Cells[i].elementName, Cells[i].spell.Description, Cells[i].spell.Effect.ToString());
            }
            if (i != Cells.Length) {
				s_Inventory += "\n";
			}
		}
		return s_Inventory;
	}

	//Clear inventory
	public void clear () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0) {
				Cells [i].elementCount = 0;
				Cells [i].UpdateCellInterface ();
			}
		}
	}

	//Add element to inventory
	public void addItem (Spell s, int count) {
		int cellId = getEquals (s.Name, s.GetColour());
		if (cellId != -1) {
			Cells [cellId].elementCount = count;
		} else {
			cellId = getFirst ();
			if (cellId == -1) {
				return;
			}
			Cells [cellId].elementCount += count;
		}
		//Set up element count
		if (Cells [cellId].elementCount > maxStack) {
			int remain = Cells [cellId].elementCount - maxStack;
			Cells [cellId].elementCount = maxStack;
			addItem (s, remain);
		} else {
			Cells [cellId].elementCount = count;
		}
		Cells [cellId].elementName = s.Name;
		Cells [cellId].elementColor = s.GetColour();
        Cells[cellId].spell = s;
        Cells [cellId].UpdateCellInterface ();
	}

	//Returns id of first clear cell
	public int getFirst () {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount == 0) {
				
				return i;
			}
		}
		return -1;
	}

	//Returns id of first same element cell
	public int getEquals (string name, Color color) {
		for (int i = 0; i < Cells.Length; i++) {
			if (Cells [i].elementCount != 0 && Cells [i].elementCount <= maxStack && Cells [i].elementName == name && Cells [i].elementColor == color) {
				return i;
			}
		}
		return -1;
	}

}
