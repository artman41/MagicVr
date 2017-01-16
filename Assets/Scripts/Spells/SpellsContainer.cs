using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Attributes;

namespace Assets.Scripts.Spells {
    public class SpellsContainer : MonoBehaviour {

        private static List<ISpell> SpellContainer = new List<ISpell>();
        
        [ReadOnly]
        public int length = SpellContainer.Count;

        // Use this for initialization
        void Start() {
        }

        // Update is called once per frame
        void Update() {

        }

        public void AddSpell(ISpell spell) {
            SpellContainer.Add(spell);
        }

        public void RemoveSpell(ISpell spell) {
            SpellContainer.Remove(spell);
        }

        public ISpell GetSpell(string s) {
            return SpellContainer.Where(o => o.Name.ToUpper() == s.ToUpper()).FirstOrDefault();
        }

        public ISpell GetSpellAt(int i) {
            return SpellContainer.ElementAt(i);
        }
    }
}