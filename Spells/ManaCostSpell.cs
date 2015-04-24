using Assets.QuarkDefault.Conditions;
using Quark;
using Quark.Spells;

public class ManaCostSpell : Spell
{
    protected float ManaCost = 15;

    protected override Condition InvokeCondition
    {
        get { return new ManaCondition(ManaCost); }
    }

    protected override EffectCollection TargetingDoneEffects
    {
        get { return base.TargetingDoneEffects + new EffectCollection { new CasterEffect(new StatEffect("mana", -ManaCost)) }; }
    }
}
