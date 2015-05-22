using Quark;
using Quark.Spells;

namespace Assets.QuarkDefault.Effects
{
    public class InterruptEffect : Effect
    {
        public override void Apply (Character target)
        {
            foreach (Cast cast in target.Casts)
                cast.Interrupt ();
        }
    }
}