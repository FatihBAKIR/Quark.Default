using Quark.Spells;
using Quark.Targeting;
using Quark;

using UnityEngine;

// Lulu Whimsy Spell

// Should give movement speed to herself and allies (currently herself only)
// Should polymorph others
// Selected Character Macro
using Assets.QuarkDefault.TargetMacros;

namespace Assets.QuarkDefault.Spells
{
    class Whimsy : Spell
    {
		public override TargetMacro TargetMacro {
			get {
				return new CharacterClick();
			}
		}

		protected override EffectCollection TargetingDoneEffects {
			get {
				Debug.Log("anan");
				return base.TargetingDoneEffects;
			}
		}
    }
}
