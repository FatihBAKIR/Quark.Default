using Quark;
using Quark.Buffs;

namespace Assets.QuarkDefault.Buffs
{
    public class EoTBuff : Buff
    {
        readonly Effect _effect;

        public EoTBuff (Effect effect, float interval, float duration)
        {
            Duration = duration;
            Interval = interval;
            StackBehavior = StackBehavior.ResetBeginning;
            _effect = effect;
        }

        protected override EffectCollection TickEffects {
            get {
                return new EffectCollection {
                    _effect
                };
            }
        }
    }
}
