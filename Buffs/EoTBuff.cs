using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Buffs
{
    public class EoTBuff
    {
        public static IBuff<T> Create<T>(IEffect<T> effect, float interval, float duration) where T : class, IContext
        {
            return new _EoTBuff<T>(effect, interval, duration);
        }

        class _EoTBuff<T> : Buff<T> where T : class, IContext
        {
            private readonly IEffect<T> _effect;

            public _EoTBuff(IEffect<T> effect, float interval, float duration)
            {
                Duration = duration;
                Interval = interval;
                StackBehavior = StackBehavior.ResetBeginning;
                _effect = effect;
            }

            protected override EffectCollection<T> TickEffects
            {
                get
                {
                    return new EffectCollection<T>
                    {
                        _effect
                    };
                }
            }
        }
    }
}
