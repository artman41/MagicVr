using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Attributes;

namespace Assets.Scripts.Spells {
    public class SpellsContainer : MonoBehaviour {

        private static List<Spell> SpellContainer = new List<Spell>();
        
        [ReadOnly]
        public int length = SpellContainer.Count;

        // Use this for initialization
        void Start() {
            AddSpell(SpellFactory.AirSpell);
            AddSpell(SpellFactory.FireSpell);
            AddSpell(SpellFactory.GroundSpell);
            AddSpell(SpellFactory.WaterSpell);
        }

        // Update is called once per frame
        void Update() {

        }

        public void AddSpell(Spell spell) {
            SpellContainer.Add(spell);
        }

        public void RemoveSpell(Spell spell) {
            SpellContainer.Remove(spell);
        }

        public Spell GetSpell(string s) {
            return SpellContainer.Where(o => o.Name.ToUpper() == s.ToUpper()).FirstOrDefault();
        }

        public Spell GetSpellAt(int i) {
            return SpellContainer.ElementAt(i);
        }
    }
}