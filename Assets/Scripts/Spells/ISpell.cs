using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Spells {
    public interface ISpell {

        string Name { get; set; }
        string Description { get; set; }
        SpellEffect Effect { get; set; }

    }
}