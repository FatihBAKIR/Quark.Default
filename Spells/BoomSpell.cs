using Quark;
using Quark.Spells;
using Quark.Targeting;

public class BoomSpell : Spell
{
    public BoomSpell()
    {
        Tags = new StaticTags { "damage" };
    }

    public override TargetMacro TargetMacro
    {
        get
        {
            return new NearestCharacter(5);
        }
    }

    protected override EffectCollection CastDoneEffects
    {
        get
        {
            return new EffectCollection {
				new DamageEffect (10)
			};
        }
    }
}