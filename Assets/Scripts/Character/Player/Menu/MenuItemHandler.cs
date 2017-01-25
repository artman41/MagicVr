using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Character.Player.Menu {
    public class MenuItemHandler : MonoBehaviour{

        public List<Button> buttons;

        GameObject Player;
        InventoryManager inv;

        bool _RanOnce;

        void Start() {

            Player = InputManager.VrCamera.transform.parent.gameObject;
            inv = Player.GetComponent<InventoryManager>();

            foreach (Button item in GetComponentsInChildren<Button>().AsEnumerable()) {
                buttons.Add(item);
                item.onClick.AddListener(delegate { ButtonListener(item); });
            }

        }

        void Update() {
        }

        void ButtonListener(Button sender) {
            GameObject cell = sender.transform.gameObject;
            Cell c = cell.GetComponent<Cell>();
            
            if(c.spell != null) {
                inv.CurrentSpell = c.spell;
            } else {
                InitSpellCreation();
            }

            Debug.Log(sender.name + " Was clicked!");
        }

        private void InitSpellCreation() {
            //TODO: create spell creation prefab
        }
    }
}
