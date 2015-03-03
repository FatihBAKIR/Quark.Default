using Quark;
using Quark.Spells;
using Quark.Targeting;

public class PullSpell : Spell
{
	public override TargetMacro TargetMacro {
		get {
			return new NearestCharacter (5);
		}
	}

	protected override EffectCollection TargetingDoneEffects {
		get {
			return new EffectCollection {
				new PullEffect(3)
			};
		}
	}
}
