using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Conditions;
using Quark.Contexts;
using Quark.Effects;
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

        protected override ConditionCollection<ICastContext> InvokeConditions
        {
            get
            {
                return new ConditionCollection<ICastContext>
                {
                    new ManaCondition(ManaCost)
                };
            }
        }

        protected override EffectCollection<ICastContext> TargetingDoneEffects
        {
            get
            {
                return base.TargetingDoneEffects +
                new EffectCollection<ICastContext>
                {
                    CasterEffect.Create(new StatEffect("mana", -ManaCost))
                };
            }
        }
    }
}
