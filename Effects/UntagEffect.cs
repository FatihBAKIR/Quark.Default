using Quark;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Effects
{
    class UntagEffect : Effect<IContext>
    {
        private readonly string _tag;
        public UntagEffect(string tag)
        {
            _tag = tag;
        }

        public override void Apply(Targetable target)
        {
            target.Untag(_tag);
        }

        public override void Apply(Character target)
        {
            Apply((Targetable)target);
        }
    }
}
