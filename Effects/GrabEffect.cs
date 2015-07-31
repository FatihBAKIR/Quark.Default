using Quark;
using Quark.Contexts;
using Quark.Effects;

namespace Assets.QuarkDefault.Effects
{
    public class GrabEffect : Effect<IContext>
    {
        private Item _item;

        public GrabEffect(Item item)
        {
            _item = item;
        }

        public override void Apply(Character target)
        {
            target.AddItem(_item);
        }
    }
}
