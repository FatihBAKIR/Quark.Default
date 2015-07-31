using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Buffs
{
    class DelayBuff : Buff<Context>
    {
        private readonly Effect<Context> _effect;

        public DelayBuff(Effect<Context> effect, float delay)
        {
            Interval = 0;
            Hidden = true;
            _effect = effect;
            Duration = delay;
        }

        protected override EffectCollection<Context> DoneEffects
        {
            get
            {
                return new EffectCollection<Context>
                {
                    _effect
                };
            }
        }
    }
}
