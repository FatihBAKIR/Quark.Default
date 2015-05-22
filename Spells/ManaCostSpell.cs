using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Spells;

namespace Assets.QuarkDefault.Spells
{
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
}
