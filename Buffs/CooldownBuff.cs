using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
namespace Assets.QuarkDefault.Buffs
{
    class CooldownBuff : Buff
    {
        public CooldownBuff(float duration)
        {
            Hidden = true;

            Duration = duration;

            Interval = 10000;
        }

        private string _tag;

        public override void OnPossess()
        {
            _tag = Context.Spell.Identifier + ".Cooldown";
            base.OnPossess();
        }

        protected override EffectCollection PossessEffects
        {
            get
            {
                return new EffectCollection
                {
                    new TagEffect(_tag)
                };
            }
        }

        protected override EffectCollection DoneEffects
        {
            get
            {
                return new EffectCollection
                {
                    new UntagEffect(_tag)
                };
            }
        }
    }
}
