using Assets.QuarkDefault.Effects;
using Quark;
using Quark.Buffs;
using Quark.Contexts;

namespace Assets.QuarkDefault.Buffs
{
    public class DoTBuff<T> : Buff<T> where T : class, IContext
    {
        /*public DoTBuff(Interaction casterInteractions, Interaction targetInteractions, float interval, float duration, float constant = 0) 
            : base(new DamageEffect (casterInteractions, targetInteractions, constant), interval, duration)
        {
        }

        public DoTBuff (float interval, float duration, float constant = 0)
            : base(new DamageEffect (constant), interval, duration)
        {
        }

        public DoTBuff(DamageEffect effect, float interval, float duration) 
            : base(effect, interval, duration)
        {
        }*/
    }
}
