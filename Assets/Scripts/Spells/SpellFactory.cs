using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Spells {
    public class SpellFactory {

        public static Spell FireSpell = CreateSpell("Fire Ball", "A ball of Fire", new SpellEffect(SpellEffectElement.Fire, SpellEffectShape.Sphere));
        public static Spell WaterSpell = CreateSpell("Water Ball", "A ball of Water", new SpellEffect(SpellEffectElement.Water, SpellEffectShape.Sphere));
        public static Spell GroundSpell = CreateSpell("Rock Ball", "A ball of Rock", new SpellEffect(SpellEffectElement.Earth, SpellEffectShape.Sphere));
        public static Spell AirSpell = CreateSpell("Air Ball", "A ball of Wind", new SpellEffect(SpellEffectElement.Air, SpellEffectShape.Sphere));

        public static Spell CreateSpell(string name, string desc, SpellEffect effect) {
            return new Spell(name, desc, effect);
        }

    }
}
