using Assets.QuarkDefault.Buffs;
using Assets.QuarkDefault.Conditions;
using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Contexts;
using Quark.Effects;
using Quark.Spells;

namespace Assets.QuarkDefault.Spells
{
    class CooldownPrototype : Spell
    {
        private string _cooldownTag;
        private float _cooldown;

        private CooldownBuff _buff;
        private CooldownCondition _condition;

        public CooldownPrototype(float cooldown)
        {
            _cooldown = cooldown;
            _buff = new CooldownBuff(cooldown);
            _condition = new CooldownCondition();
        }

        public CooldownPrototype(string tag, float cooldown)
            : this(cooldown)
        {
            _cooldownTag = tag;
            _buff = new CooldownBuff(tag, cooldown);
            _condition = new CooldownCondition(tag);
        }

        protected override EffectCollection<ICastContext> CastDoneEffects
        {
            get
            {
                return new EffectCollection<ICastContext>
                {
                    CasterEffect.Create(BuffEffect.Create(_buff))
                };
            }
        }

        protected override ConditionCollection<ICastContext> InvokeConditions
        {
            get
            {
                return new ConditionCollection<ICastContext>
                {
                    _condition
                };
            }
        }
    }
}
