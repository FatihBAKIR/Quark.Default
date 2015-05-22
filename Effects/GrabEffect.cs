using Quark;

namespace Assets.QuarkDefault.Effects
{
    public class GrabEffect : Effect
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
