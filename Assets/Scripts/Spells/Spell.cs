using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
