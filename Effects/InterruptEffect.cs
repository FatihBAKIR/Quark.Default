using Quark;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Effects
{
    public class InterruptEffect : Effect<IContext>
    {
        public override void Apply (Character target)
        {
            foreach (ICastContext cast in target.Casts)
                cast.Interrupt ();
        }
    }
}