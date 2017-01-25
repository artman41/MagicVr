using Eppy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts;
using UnityEngine;

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

    public class SpellEffect{
        public SpellEffectElement Element { get; set; }
        public SpellEffectShape Shape { get; set; }
        List<Tuple<SpellEffectModifier, int>> _Modifiers = new List<Tuple<SpellEffectModifier, int>>();
        List<Tuple<SpellEffectModifier, int>> Modifiers {
            get { return _Modifiers; }
            set { _Modifiers = value; }
        }

        public SpellEffect(SpellEffectElement e, SpellEffectShape s) {
            Element = e;
            Shape = s;
        }

        public SpellEffect(SpellEffectElement e, SpellEffectShape s, List<Tuple<SpellEffectModifier, int>> m) : this(e, s) {
            if (m != null) {
                Modifiers = m;
            }
        }

        public SpellEffect(SpellEffectElement e, SpellEffectShape s, Tuple<SpellEffectModifier, int> m) : this(e, s) {
            if (m != null) {
                Modifiers.Add(m);
            }
        }

        /// <summary>
        /// Returns the values of the spell as a string
        /// </summary>
        /// <returns>Element-Shape-[Modifiers]</returns>
        public override string ToString() {
            return string.Format("{0}-{1}-{2}", Element, Shape, string.Format("{0}", ModifiersToString()));
        }

        string ModifiersToString() {
            string s = string.Empty;
            for (int i = 0; i < Modifiers.Count; i++) {
                var x = Modifiers.ElementAt(i);
                if (x != Modifiers.ElementAt(Modifiers.Count - 1)) {
                    s += string.Format("{0}|{1}, ", x.Item1, x.Item2);
                } else {
                    s += string.Format("{0}|{1}", x.Item1, x.Item2);
                }
            }

            return s;
        }

        public static SpellEffectElement GetElementFromString(string s) {
           return (SpellEffectElement)Enum.Parse(typeof(SpellEffectElement), s);
        }

        public static SpellEffectShape GetShapeFromString(string s) {
            return (SpellEffectShape)Enum.Parse(typeof(SpellEffectShape), s);
        }

        public static List<Tuple<SpellEffectModifier, int>> GetModifiersFromString(string[] s) {
            List<Tuple<SpellEffectModifier, int>> l = new List<Tuple<SpellEffectModifier, int>>();
            foreach (var item in s) {
                var x = item.Split('|');
                l.Add(new Tuple<SpellEffectModifier, int>((SpellEffectModifier)Enum.Parse(typeof(SpellEffectModifier), x[0]), int.Parse(x[1])));
            }
            return l;
        }

        public static GameObject GetGameObject(SpellEffectElement e) {
            GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/SpellEffect")) as GameObject;
            Material m =go.GetComponent<MeshRenderer>().materials[1];
            m.color = Spell.GetColour(e, 93);
            go.GetComponent<MeshRenderer>().materials[1] = m;
            go.transform.position = Vector3.zero;
            return go;
        }

        public static GameObject GetGameObject(SpellEffectShape e) {
            return new GameObject();
        }

        public static GameObject GetGameObject(SpellEffectModifier e) {
            return new GameObject();
        }
    }
}
