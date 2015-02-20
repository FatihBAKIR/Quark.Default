using Quark;
using Quark.Buff;
using Quark.Spell;
using Quark.Targeting;

public class IgniteSpell : Spell
{
	public override string Name {
		get {
			return "Ignite";
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
				new BuffEffect(new DoTBuff())
			};
		}
	}
}