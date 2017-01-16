using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.Spells;

namespace Assets.Scripts.Character.Player.Menu {
    public class MenuHandler : MonoBehaviour {

        public MenuType Type = MenuType.SpellBrowser;

        GameObject Parent { get; set; }

        GameObject CanvasHolder;

        bool IsMenuOpen;

        // Use this for initialization
        void Start() {
            CanvasHolder = new GameObject();
            Parent = this.transform.parent.gameObject;

        }

        // Update is called once per frame
        void Update() {
            if (Input.GetKeyDown("Menu1")) {
                CanvasHolder.AddComponent<Canvas>();

                Canvas canvas = CanvasHolder.GetComponent<Canvas>();
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                FillCanvas(canvas);

                /*CanvasHolder.AddComponent<Text>();
                Text textComponent = CanvasHolder.GetComponent<Text>();
                Material newMaterialRef = Resources.Load<Material>("3DTextCoolVetica");
                Font myFont = Resources.Load<Font>("coolvetica rg");

                textComponent.font = myFont;
                textComponent.material = newMaterialRef;
                textComponent.text = "Hello World";*/
              //  myGO.AddComponent<Slider>();
            }
        }

        Canvas FillCanvas(Canvas c) {
            switch (Type) {
                case MenuType.SpellBrowser:
                var sc = Parent.GetComponent<SpellsContainer>();
                for (int i = 0; i < sc.length; i++) {
                    ISpell spell = sc.GetSpellAt(i);
                    GameObject go = new GameObject();
                    go.name = spell.Name;
                    go.tag = spell.Effect.ToString();
                    go.AddComponent<Text>();
                    Text t = CanvasHolder.GetComponent<Text>();
                    t.text = spell.Name;
                    go.transform.SetParent(CanvasHolder.transform);
                }

                break;
                case MenuType.SpellCreator:
                break;
            }
            return c;
        }
    }
}