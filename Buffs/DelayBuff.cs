using Quark;
using Quark.Buffs;

namespace Assets.QuarkDefault.Buffs
{
    class DelayBuff : Buff
    {
        private readonly Effect _effect;

        public DelayBuff(Effect effect, float delay)
        {
            Interval = 0;
            Hidden = true;
            _effect = effect;
            Duration = delay;
        }

        protected override EffectCollection DoneEffects
        {
            get
            {
                return new EffectCollection
                {
                    _effect
                };
            }
        }
    }
}
