using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Spells;

namespace Assets.QuarkDefault.Spells
{
    public class ManaCostSpell : Spell
    {
        public ManaCostSpell(float manaCost = 0)
        {
            ManaCost = manaCost;
        }

        public float ManaCost;

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
