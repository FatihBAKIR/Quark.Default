using Assets.QuarkDefault.Effects;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;
using UnityEngine;

namespace Assets.QuarkDefault.Buffs
{
    class CooldownBuff : Buff<ICastContext>
    {
        private bool _fromContext;
        private string _cooldownTag;

        public CooldownBuff(string tag, float duration)
            : this(duration)
        {
            _fromContext = false;
            _cooldownTag = tag;
        }

        public CooldownBuff(float duration)
        {
            _fromContext = true;
            Hidden = true;
            Duration = duration;
            Interval = 10000;
        }

        private string _tag;

        public override void OnPossess()
        {
            _tag = (_fromContext ? Context.Spell.Identifier : _cooldownTag) + ".Cooldown";
            base.OnPossess();
        }

        protected override EffectCollection<ICastContext> PossessEffects
        {
            get
            {
                return new EffectCollection<ICastContext>
                {
                    new TagEffect(_tag)
                };
            }
        }

        protected override EffectCollection<ICastContext> DoneEffects
        {
            get
            {
                return new EffectCollection<ICastContext>
                {
                    new UntagEffect(_tag)
                };
            }
        }
    }
}
