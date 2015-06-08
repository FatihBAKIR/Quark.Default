using Quark;

namespace Assets.QuarkDefault.Effects
{
    class TagEffect : Effect
    {
        private readonly string _tag;
        private readonly object _val;
        public TagEffect(string tag)
        {
            _tag = tag;
            _val = true;
        }

        public TagEffect(string tag, object value)
        {
            _tag = tag;
            _val = value;
        }

        public override void Apply(Targetable target)
        {
            target.Tag(_tag, _val);
        }

        public override void Apply(Character target)
        {
            Apply((Targetable)target);
        }
    }
}
