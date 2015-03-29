using Quark;
using Quark.Targeting;

public class IgniteSpell : ManaCostSpell
{
    public IgniteSpell ()
    {
        ManaCost = 30;
    }

	public override TargetMacro TargetMacro {
		get {
			return new NearestCharacter(5);
		}
	}

	protected override EffectCollection TargetingDoneEffects {
		get {
			return base.TargetingDoneEffects + new EffectCollection {
				new BuffEffect(new DoTBuff(1, 10, 10))
			};
		}
	}
}