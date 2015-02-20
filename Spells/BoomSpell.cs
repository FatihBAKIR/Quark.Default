using Quark;
using Quark.Spell;
using Quark.Targeting;

public class BoomSpell : Spell
{
	public override string Name {
		get {
			return "BOOM";
		}
	}

	public override TargetMacro TargetMacro {
		get {
			return new NearestCharacter(5);
		}
	}

	protected override EffectCollection TargetingDoneEffects {
		get {
			return new EffectCollection {
				new DamageEffect (10)
			};
		}
	}
}