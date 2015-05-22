using Assets.QuarkDefault.Effects;
using Quark;

namespace Assets.QuarkDefault.Items
{
    public class LogItem : Item
    {
        protected override EffectCollection GrabEffects
        {
            get
            {
                return new EffectCollection
                {
                    new LogEffect("Item Grabbed: " + Identifier)
                };
            }
        }
    }
}
