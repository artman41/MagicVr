using Eppy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Spells {
    public enum SpellEffectElement {
        Fire, Water, Earth, Air
    }
    public enum SpellEffectShape {
        Sphere, Cube, Cylinder
    }
    public enum SpellEffectModifier {
        Explosive, Shatter, Multiply, Grow, Shrink
    }

    public class SpellEffect {
        SpellEffectElement Element { get; set; }
        SpellEffectShape Shape { get; set; }
        List<Tuple<SpellEffectModifier, int>> _Modifiers = new List<Tuple<SpellEffectModifier, int>>();
        List<Tuple<SpellEffectModifier, int>> Modifiers {
            get { return _Modifiers; }
            set { _Modifiers = value; }
        }

        public SpellEffect(SpellEffectElement e, SpellEffectShape s) {
            Element = e;
            Shape = s;
        }

        public SpellEffect(SpellEffectElement e, SpellEffectShape s, List<Tuple<SpellEffectModifier, int>> m) : this(e, s){
            if (m != null) {
                Modifiers = m;
            }
        }

        public SpellEffect(SpellEffectElement e, SpellEffectShape s, Tuple<SpellEffectModifier, int> m) : this(e,s){
            if(m != null) {
                Modifiers.Add(m);
            }
        }
    }
}
