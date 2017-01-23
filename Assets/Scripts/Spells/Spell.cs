using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Spells {
    public class Spell : ISpell {

        public string Name { get; set; }
        public string Description { get; set; }
        public SpellEffect Effect { get; set; }

        internal Spell(String n, String d, SpellEffect e) {
            Name = n;
            Description = d;
            Effect = e;
        }

        public Color GetColour() {
            switch (this.Effect.Element) {
                case SpellEffectElement.Air:
                    return Color.white;
                case SpellEffectElement.Earth:
                    return FromRGB(165, 42, 42); //brown
                case SpellEffectElement.Fire:
                    return Color.red;
                case SpellEffectElement.Water:
                    return Color.blue;
                default:
                    return Color.black;
            }
        }

        public Color FromRGB(byte r, byte g, byte b, byte a = 255) {
            return new Color32(r, g, b, a);
        }
    }
}
