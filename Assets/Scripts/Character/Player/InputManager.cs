using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Character.Player {
    public class InputManager : MonoBehaviour {

        InventoryManager invMan;
        Gravity g;

        public KeyCode clearInv = KeyCode.C;
        public KeyCode saveInv = KeyCode.P;
        public KeyCode loadInv = KeyCode.L;
        public KeyCode interactInv = KeyCode.Tab;
        public KeyCode exit = KeyCode.Escape;
        public static Camera VrCamera;


        void Start() {
            invMan = GetComponent<InventoryManager>();
            g = GetComponent<Gravity>();
            VrCamera = Camera.allCameras[0];
        }

        void Update() {
            #region Inventory
            if (invMan.inventory != null) {
                //if (Input.GetKeyDown (KeyCode.G)) {
                //	inventory.addItem (SimpleMethods.randomElement(), Random.Range(1, inventory.maxStack), new Color(Random.value/2f, Random.value/2f, Random.value/2f, 1f));
                //}

                if (Input.GetKeyDown(clearInv)) {
                    invMan.inventory.clear();
                }
                if (Input.GetKeyDown(saveInv)) {
                    PlayerPrefs.SetString("EInventory", invMan.inventory.convertToString());
                }
                if (Input.GetKeyDown(loadInv)) {
                    invMan.inventory.loadFromString(PlayerPrefs.GetString("EInventory"));
                }
                if (Input.GetKeyDown(interactInv)) {
                    invMan.inventory.gameObject.SetActive(!invMan.inventory.gameObject.activeInHierarchy);
                }
            }
            #endregion

            if (Input.GetKeyDown(exit)) {
                Application.Quit();
                Debug.Log("Attempting to close");
            }

            #region Movement
            if (g.controller.isGrounded) {
                Vector3 forward = VrCamera.transform.TransformDirection(Vector3.forward);
                forward.y = 0;
                forward = forward.normalized;
                Vector3 right = new Vector3(forward.z, 0, -forward.x);

                g.moveDirection = Input.GetAxis("Horizontal")*right + Input.GetAxis("Vertical")*forward;
                g.moveDirection = transform.TransformDirection(g.moveDirection);
                g.moveDirection *= g.speed;
                if (Input.GetButton("Jump")) {
                    g.moveDirection.y = g.jumpSpeed;
                }
            }



            g.moveDirection.y -= g.gravity * Time.deltaTime;
            g.controller.Move(g.moveDirection * Time.deltaTime);
            #endregion
        }
    }
}
