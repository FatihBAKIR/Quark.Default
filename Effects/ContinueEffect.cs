using Quark;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Effects
{
    class ContinueEffect : Effect<IContext>
    {
        public override void Apply(Character target)
        {
            target.Continue();
        }
    }
}
